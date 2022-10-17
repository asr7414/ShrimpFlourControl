using ShrimpFlourControl.Maps;
using ShrimpFlourControl.Missions;
using ShrimpFlourControl.PathPlanner;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ShrimpFlourControl.Vehicles.AGV;

namespace ShrimpFlourControl.Vehicles
{
    public class AGVHandler
    {
        public SFCServer SFC;
        public AStarPlanner PathPlanner;
        public AGVHandler(SFCServer SFC)
        {
            this.SFC = SFC;
            this.PathPlanner = new AStarPlanner(SFC);
        }
        public AGV FindFitnessAGV(Node machineNode)   //  派車邏輯(車輛選擇)
        {
            AStarPlanner _pathPlanner = new AStarPlanner(SFC);
            var result = this.SFC.AGVs.Where(a => a.State == AGVStates.Idle && a.IsOccupied == false);
            if (result.Count() == 1)
            {
                return result.First();

            }else if (result.Count() >= 2)
            {
                return result.Select(a => new { agv = a, distinct = PathPlanner.Distance(a.CurrentNode, machineNode) }).OrderBy(a => a.distinct).First().agv;
            }
            else
            {
                return null;
            }
        }

        public Thread SendAGVTo(Node destinateNode, AGV selectAGV, Func<bool> callback, Func<bool> startProcessing = null) // 車輛派遣
        {
            var routePath = PathPlanner.FindPath(selectAGV.CurrentNode, destinateNode);
            Debug.WriteLine("node" + destinateNode.ID + " agv" + selectAGV.AgvId);
            if (routePath != null)
            {
                foreach (var node in routePath)
                {
                    //Debug.WriteLine($"{node.ID}");
                }


                //var targetAGV = this.SFC.AGVs.FirstOrDefault(agv => agv.CurrentNode == departNode);
                var targetAGV = selectAGV;
                if (targetAGV != null)
                {
                    var t = new Thread(() =>
                    {
                        targetAGV.State = AGVStates.Moving;
                        //targetAGV.Move(routePath);
                        //Debug.WriteLine(targetAGV.AgvId + " Moving");
                        for (int i = 1; i < routePath.Count; i++)
                        {
                            float speedFactor = 3.0f;
                            float threshold = 5.0f;
                            var startNode = routePath[i - 1];
                            var endNode = routePath[i];
                            var targetPath = this.SFC.Paths.FirstOrDefault(path => path.StartNode == startNode && path.EndNode == endNode);
                            if (targetPath == null)
                            {
                                targetPath = this.SFC.Paths.FirstOrDefault(path => path.StartNode == endNode && path.EndNode == startNode);
                                if (targetPath != null)
                                {
                                    targetPath = new Path(targetPath.ID, targetPath.EndNode, targetPath.StartNode, targetPath.Type, targetPath.CornerPosX, targetPath.CornerPosY, targetPath.Radius, targetPath.Direction);
                                }
                            }
                            if (targetPath == null)
                            {
                                MessageBox.Show("Can not find any path");
                            }


                            switch (targetPath.Type)
                            {
                                case Path.PathType.Line:
                                    var initDistance = Math.Pow(Math.Pow(targetAGV.X - endNode.PosX, 2) + Math.Pow(targetAGV.Y - endNode.PosY, 2), 0.5);
                                    var vectorX = (endNode.PosX - startNode.PosX) / initDistance * speedFactor;
                                    var vectorY = (endNode.PosY - startNode.PosY) / initDistance * speedFactor;

                                    while (true)
                                    {
                                        var distance = Math.Pow(Math.Pow(targetAGV.X - endNode.PosX, 2) + Math.Pow(targetAGV.Y - endNode.PosY, 2), 0.5);
                                        targetAGV.X += (float)vectorX;
                                        targetAGV.Y += (float)vectorY;

                                        if (distance < threshold)
                                        {
                                            break;
                                        }
                                        Thread.Sleep(10);
                                    }
                                    targetAGV.X = targetAGV.X;
                                    targetAGV.Y = targetAGV.Y;
                                    targetAGV.CurrentNode = endNode;
                                    break;
                                case Path.PathType.Curve90:
                                case Path.PathType.CurveAny:
                                    // 三上優雅
                                    Vector2 v1 = new Vector2(targetPath.StartNode.PosX - targetPath.CornerPosX, targetPath.StartNode.PosY - targetPath.CornerPosY);
                                    Vector2 v2 = new Vector2(targetPath.EndNode.PosX - targetPath.CornerPosX, targetPath.EndNode.PosY - targetPath.CornerPosY);
                                    var theta = Math.Acos(Vector2.Dot(v1, v2) / (v1.Length() * v2.Length()));
                                    var beta = Math.PI / 2 - theta / 2;
                                    var l = targetPath.Radius / Math.Cos(beta);
                                    var ll = l * Math.Cos(theta / 2);
                                    Vector2 v3 = v1 / v1.Length() + v2 / v2.Length();
                                    var centerX = targetPath.CornerPosX + v3.X / v3.Length() * l;
                                    var centerY = targetPath.CornerPosY + v3.Y / v3.Length() * l;

                                    var p1X = targetPath.CornerPosX + v1.X / v1.Length() * ll;
                                    var p1Y = targetPath.CornerPosY + v1.Y / v1.Length() * ll;
                                    var p2X = targetPath.CornerPosX + v2.X / v2.Length() * ll;
                                    var p2Y = targetPath.CornerPosY + v2.Y / v2.Length() * ll;

                                    Vector2 vc1 = new Vector2((float)(p1X - centerX), (float)(p1Y - centerY));
                                    Vector2 vc2 = new Vector2((float)(p2X - centerX), (float)(p2Y - centerY));
                                    var startAngle = Math.Acos(Vector2.Dot(Vector2.UnitX, vc1) / (vc1.Length()));
                                    var sweepAngle = Math.Acos(Vector2.Dot(vc1, vc2) / (vc1.Length() * vc2.Length()));
                                    var vcc = Vector3.Cross(new Vector3(vc1, 0), new Vector3(vc2, 0));
                                    if (vcc.Z < 0)
                                    {
                                        sweepAngle = -sweepAngle;
                                    }

                                    if (p1Y < centerY)
                                    {
                                        Debug.WriteLine(Vector2.Dot(Vector2.UnitX, vc1));
                                        startAngle = 2 * Math.PI - startAngle;
                                    }
                                    // 第一上                                                        
                                    var initDistance1 = Math.Pow(Math.Pow(targetAGV.X - p1X, 2) + Math.Pow(targetAGV.Y - p1Y, 2), 0.5);
                                    var vectorX1 = (p1X - startNode.PosX) / initDistance1 * speedFactor;
                                    var vectorY1 = (p1Y - startNode.PosY) / initDistance1 * speedFactor;

                                    while (true)
                                    {
                                        var distance = Math.Pow(Math.Pow(targetAGV.X - p1X, 2) + Math.Pow(targetAGV.Y - p1Y, 2), 0.5);
                                        targetAGV.X += (float)vectorX1;
                                        targetAGV.Y += (float)vectorY1;

                                        if (distance < threshold)
                                        {
                                            break;
                                        }
                                        Thread.Sleep(10);
                                    }
                                    targetAGV.X = (float)p1X;
                                    targetAGV.Y = (float)p1Y;

                                    // 第二上
                                    Func<double, double> Y = x => Math.Sqrt(Math.Pow(targetPath.Radius, 2) + Math.Pow(x - centerX, 2)) + centerY;
                                    var unitAngle = sweepAngle / (2 * Math.PI) * speedFactor / 10;
                                    var targetAngle = startAngle + sweepAngle;
                                    var angle = startAngle;

                                    while (true)
                                    {
                                        angle += unitAngle;
                                        targetAGV.X = (float)(targetPath.Radius * Math.Cos(angle) + centerX);
                                        targetAGV.Y = (float)(targetPath.Radius * Math.Sin(angle) + centerY);

                                        if (Math.Abs(targetAngle - angle) < 0.03)
                                        {
                                            break;
                                        }
                                        Thread.Sleep(10);
                                    }
                                    targetAGV.X = (float)p2X;
                                    targetAGV.Y = (float)p2Y;

                                    // 第三上
                                    var initDistance3 = Math.Pow(Math.Pow(targetAGV.X - endNode.PosX, 2) + Math.Pow(targetAGV.Y - endNode.PosY, 2), 0.5);
                                    var vectorX3 = (endNode.PosX - p2X) / initDistance3 * speedFactor;
                                    var vectorY3 = (endNode.PosY - p2Y) / initDistance3 * speedFactor;

                                    while (true)
                                    {
                                        var distance = Math.Pow(Math.Pow(targetAGV.X - endNode.PosX, 2) + Math.Pow(targetAGV.Y - endNode.PosY, 2), 0.5);
                                        targetAGV.X += (float)vectorX3;
                                        targetAGV.Y += (float)vectorY3;

                                        if (distance < threshold)
                                        {
                                            break;
                                        }
                                        Thread.Sleep(10);
                                    }
                                    targetAGV.X = endNode.PosX;
                                    targetAGV.Y = endNode.PosY;
                                    targetAGV.CurrentNode = endNode;
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetAGV.State = AGVStates.Idle;
                        //Debug.WriteLine(targetAGV.AgvId + " Idle");
                        if (callback != null)
                        {
                            callback();
                        }
                        if (startProcessing != null)
                        {
                            startProcessing();
                        }
                    })
                    {
                        IsBackground = true
                    };
                    return t;
                }
                return null;
            }
            return null;
        }
        public void SendAGVTo2(Node destinateNode, AGV selectAGV) // 車輛派遣
        {
            var routePath = PathPlanner.FindPath(selectAGV.CurrentNode, destinateNode);
            Debug.WriteLine("node" + destinateNode.ID + " agv" + selectAGV.AgvId);
            if (routePath != null)
            {
                foreach (var node in routePath)
                {
                    //Debug.WriteLine($"{node.ID}");
                }


                //var targetAGV = this.SFC.AGVs.FirstOrDefault(agv => agv.CurrentNode == departNode);
                var targetAGV = selectAGV;
                if (targetAGV != null)
                {
                    
                        targetAGV.State = AGVStates.Moving;
                        //targetAGV.Move(routePath);
                        //Debug.WriteLine(targetAGV.AgvId + " Moving");
                        for (int i = 1; i < routePath.Count; i++)
                        {
                            float speedFactor = 3.0f;
                            float threshold = 5.0f;
                            var startNode = routePath[i - 1];
                            var endNode = routePath[i];
                            var targetPath = this.SFC.Paths.FirstOrDefault(path => path.StartNode == startNode && path.EndNode == endNode);
                            if (targetPath == null)
                            {
                                targetPath = this.SFC.Paths.FirstOrDefault(path => path.StartNode == endNode && path.EndNode == startNode);
                                if (targetPath != null)
                                {
                                    targetPath = new Path(targetPath.ID, targetPath.EndNode, targetPath.StartNode, targetPath.Type, targetPath.CornerPosX, targetPath.CornerPosY, targetPath.Radius, targetPath.Direction);
                                }
                            }
                            if (targetPath == null)
                            {
                                MessageBox.Show("Can not find any path");
                            }


                            switch (targetPath.Type)
                            {
                                case Path.PathType.Line:
                                    var initDistance = Math.Pow(Math.Pow(targetAGV.X - endNode.PosX, 2) + Math.Pow(targetAGV.Y - endNode.PosY, 2), 0.5);
                                    var vectorX = (endNode.PosX - startNode.PosX) / initDistance * speedFactor;
                                    var vectorY = (endNode.PosY - startNode.PosY) / initDistance * speedFactor;

                                    while (true)
                                    {
                                        var distance = Math.Pow(Math.Pow(targetAGV.X - endNode.PosX, 2) + Math.Pow(targetAGV.Y - endNode.PosY, 2), 0.5);
                                        targetAGV.X += (float)vectorX;
                                        targetAGV.Y += (float)vectorY;

                                        if (distance < threshold)
                                        {
                                            break;
                                        }
                                        Thread.Sleep(10);
                                    }
                                    targetAGV.X = targetAGV.X;
                                    targetAGV.Y = targetAGV.Y;
                                    targetAGV.CurrentNode = endNode;
                                    break;
                                case Path.PathType.Curve90:
                                case Path.PathType.CurveAny:
                                    // 三上優雅
                                    Vector2 v1 = new Vector2(targetPath.StartNode.PosX - targetPath.CornerPosX, targetPath.StartNode.PosY - targetPath.CornerPosY);
                                    Vector2 v2 = new Vector2(targetPath.EndNode.PosX - targetPath.CornerPosX, targetPath.EndNode.PosY - targetPath.CornerPosY);
                                    var theta = Math.Acos(Vector2.Dot(v1, v2) / (v1.Length() * v2.Length()));
                                    var beta = Math.PI / 2 - theta / 2;
                                    var l = targetPath.Radius / Math.Cos(beta);
                                    var ll = l * Math.Cos(theta / 2);
                                    Vector2 v3 = v1 / v1.Length() + v2 / v2.Length();
                                    var centerX = targetPath.CornerPosX + v3.X / v3.Length() * l;
                                    var centerY = targetPath.CornerPosY + v3.Y / v3.Length() * l;

                                    var p1X = targetPath.CornerPosX + v1.X / v1.Length() * ll;
                                    var p1Y = targetPath.CornerPosY + v1.Y / v1.Length() * ll;
                                    var p2X = targetPath.CornerPosX + v2.X / v2.Length() * ll;
                                    var p2Y = targetPath.CornerPosY + v2.Y / v2.Length() * ll;

                                    Vector2 vc1 = new Vector2((float)(p1X - centerX), (float)(p1Y - centerY));
                                    Vector2 vc2 = new Vector2((float)(p2X - centerX), (float)(p2Y - centerY));
                                    var startAngle = Math.Acos(Vector2.Dot(Vector2.UnitX, vc1) / (vc1.Length()));
                                    var sweepAngle = Math.Acos(Vector2.Dot(vc1, vc2) / (vc1.Length() * vc2.Length()));
                                    var vcc = Vector3.Cross(new Vector3(vc1, 0), new Vector3(vc2, 0));
                                    if (vcc.Z < 0)
                                    {
                                        sweepAngle = -sweepAngle;
                                    }

                                    if (p1Y < centerY)
                                    {
                                        Debug.WriteLine(Vector2.Dot(Vector2.UnitX, vc1));
                                        startAngle = 2 * Math.PI - startAngle;
                                    }
                                    // 第一上                                                        
                                    var initDistance1 = Math.Pow(Math.Pow(targetAGV.X - p1X, 2) + Math.Pow(targetAGV.Y - p1Y, 2), 0.5);
                                    var vectorX1 = (p1X - startNode.PosX) / initDistance1 * speedFactor;
                                    var vectorY1 = (p1Y - startNode.PosY) / initDistance1 * speedFactor;

                                    while (true)
                                    {
                                        var distance = Math.Pow(Math.Pow(targetAGV.X - p1X, 2) + Math.Pow(targetAGV.Y - p1Y, 2), 0.5);
                                        targetAGV.X += (float)vectorX1;
                                        targetAGV.Y += (float)vectorY1;

                                        if (distance < threshold)
                                        {
                                            break;
                                        }
                                        Thread.Sleep(10);
                                    }
                                    targetAGV.X = (float)p1X;
                                    targetAGV.Y = (float)p1Y;

                                    // 第二上
                                    Func<double, double> Y = x => Math.Sqrt(Math.Pow(targetPath.Radius, 2) + Math.Pow(x - centerX, 2)) + centerY;
                                    var unitAngle = sweepAngle / (2 * Math.PI) * speedFactor / 10;
                                    var targetAngle = startAngle + sweepAngle;
                                    var angle = startAngle;

                                    while (true)
                                    {
                                        angle += unitAngle;
                                        targetAGV.X = (float)(targetPath.Radius * Math.Cos(angle) + centerX);
                                        targetAGV.Y = (float)(targetPath.Radius * Math.Sin(angle) + centerY);

                                        if (Math.Abs(targetAngle - angle) < 0.03)
                                        {
                                            break;
                                        }
                                        Thread.Sleep(10);
                                    }
                                    targetAGV.X = (float)p2X;
                                    targetAGV.Y = (float)p2Y;

                                    // 第三上
                                    var initDistance3 = Math.Pow(Math.Pow(targetAGV.X - endNode.PosX, 2) + Math.Pow(targetAGV.Y - endNode.PosY, 2), 0.5);
                                    var vectorX3 = (endNode.PosX - p2X) / initDistance3 * speedFactor;
                                    var vectorY3 = (endNode.PosY - p2Y) / initDistance3 * speedFactor;

                                    while (true)
                                    {
                                        var distance = Math.Pow(Math.Pow(targetAGV.X - endNode.PosX, 2) + Math.Pow(targetAGV.Y - endNode.PosY, 2), 0.5);
                                        targetAGV.X += (float)vectorX3;
                                        targetAGV.Y += (float)vectorY3;

                                        if (distance < threshold)
                                        {
                                            break;
                                        }
                                        Thread.Sleep(10);
                                    }
                                    targetAGV.X = endNode.PosX;
                                    targetAGV.Y = endNode.PosY;
                                    targetAGV.CurrentNode = endNode;
                                    break;
                                default:
                                    break;
                            }
                        }
                        targetAGV.State = AGVStates.Idle;
                }
            }
        }
    }
}
