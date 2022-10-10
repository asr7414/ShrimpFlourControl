using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShrimpFlourControl.Maps;
using ShrimpFlourControl.Stations;
using ShrimpFlourControl.Vehicles;
using System.Numerics;

namespace ShrimpFlourControl.Visualizations
{
    public class MapDrawer
    {
        private SFCServer _sfc;
        private Bitmap _picture;
        private float _scale;
        private float offsetX;
        private float offsetY;
        private const int _nodeSize = 32;
        private const int _agvSize = 32;
        private const int _initialgridsize = 20;
        private const int _initialgridscale = 1;
        private bool _gridState = false;
        public Node StartNode { get; set;}
        public Node EndNode  { get; set;}
        public Node CurveNode1 { get; set; }
        public Node CurveNode2 { get; set; }
        public Point CurveCornerPoint { get; set; }

        public MapDrawer(SFCServer sfc)
        {
            _sfc = sfc;
        }

        public Bitmap Render(int width, int height, float scale = 1.0f)
        {
            _picture?.Dispose();
            //if(_picture != null)
            //{
            //    _picture.Dispose();
            //}
            _picture = new Bitmap(width, height);
            _scale = scale;
            DrawPaths();
            DrawNodes();
            DrawStations();
            DrawAGVs();
            //DrawGridMap();
            return _picture;
        }


        public Node GetNode(Point mouseLocation)
        {
            foreach (var node in _sfc.Nodes)
            {
                var nodeSelect = new Rectangle(new Point(node.PosX - _nodeSize/2, node.PosY - _nodeSize/2), new Size(_nodeSize, _nodeSize));
                if (nodeSelect.Contains(mouseLocation))
                {
                    return node;
                }
            }
            return null;
        }

        public AGV GetAGV(Point mouseLocation)    ///選車
        {
            foreach (var agv in _sfc.AGVs)
            {
                var agvRect = new Rectangle(new Point((int)agv.X - _agvSize/2, (int)agv.Y - _agvSize/2), new Size(_agvSize, _agvSize));
                if (agvRect.Contains(mouseLocation))
                {
                    return agv;
                }
            }
            return null;
        }

        public Station GetStation(Point mouseLocation)   ///選工作站
        {

            foreach (var station in _sfc.Stations)///////////需算offset
            {
                var StationLocationX = station.ReferNode.PosX + station.OffsetX;
                var StationLocationY = station.ReferNode.PosY + station.OffsetY;
                //Debug.WriteLine("滑鼠點擊位置為 = " + (station.Location.X - (sta_length / 2)).ToString() + "," + (station.Location.Y - (sta_width / 2)));                                
                var size = station.GetStationSize();
                var width = size.X;
                var height = size.Y;
                var StaSelect = new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height));


                if (StaSelect.Contains(mouseLocation))
                {
                    return station;
                }
            }
            return null;
        }
        public void DrawGridMap()
        {
            _gridState = true;

            //var bitMap = new Bitmap(Grid_picturebox.Width, Grid_picturebox.Height);
            var bitMap = new Bitmap(_picture.Width, _picture.Height);
            using (var g = Graphics.FromImage(_picture))
            {
                float startx, starty, endx, endy;
                startx = 0;
                starty = 0;
                endx = bitMap.Width;
                endy = bitMap.Height;

                for (int i = 1; i < _picture.Width; i++)
                {
                    g.DrawLine(new Pen(Color.FromArgb(128, 220, 220, 220), 1), (startx + _initialgridsize) * i * _initialgridscale, starty * i * _initialgridscale, (startx + _initialgridsize) * i * _initialgridscale, endy * i * _initialgridscale);
                    for (int j = 1; j < _picture.Height; j++)
                    {
                        g.DrawLine(new Pen(Color.FromArgb(128, 220, 220, 220), 1), startx * j * _initialgridscale, (starty + _initialgridsize) * j * _initialgridscale, endx * j * _initialgridscale, (starty + _initialgridsize) * j * _initialgridscale);
                    }
                }
            }
        }
        private void DrawNodes()
        {
            using (var graphics = Graphics.FromImage(_picture))
            {
                foreach (var node in _sfc.Nodes)
                {
                    // Snap node on grid                  
                    graphics.DrawImage(Properties.Resources.normal_node, new Rectangle(new Point(node.PosX - _nodeSize/2, node.PosY - _nodeSize/2), new Size(_nodeSize, _nodeSize)));
                    graphics.DrawString(node.ID.ToString(), new Font("Arial", 16), Brushes.Black, new Point(node.PosX + 10, node.PosY + 10));
                    if (node == _sfc.SelectedNode)
                    {
                        graphics.DrawImage(Properties.Resources.select_node, node.PosX - _nodeSize/2, node.PosY - _nodeSize/2, _nodeSize, _nodeSize);
                    }

                    if (node == _sfc.SelectedPathNode1)
                    {
                        graphics.FillEllipse(Brushes.Green, node.PosX - _nodeSize/2, node.PosY - _nodeSize/2, _nodeSize, _nodeSize);
                    }
                    else if (node == _sfc.SelectedPathNode2)
                    {
                        graphics.FillEllipse(Brushes.Red, node.PosX - _nodeSize/2, node.PosY - _nodeSize/2, _nodeSize, _nodeSize);
                    }
                }
            }
        }

        private void DrawPaths()
        {
            using (var graphics = Graphics.FromImage(_picture))
            {
                foreach (var path in _sfc.Paths)
                {
                    if (path.Type == Path.PathType.Line)
                    {
                        if (path == _sfc.SelectedPath)
                        {
                            graphics.DrawLine(new Pen(Color.Red, 3), path.StartNode.PosX, path.StartNode.PosY, path.EndNode.PosX, path.EndNode.PosY);
                        }
                        else
                        {
                            graphics.DrawLine(new Pen(Color.Blue, 3), path.StartNode.PosX, path.StartNode.PosY, path.EndNode.PosX, path.EndNode.PosY);
                        }

                    }
                    else if (path.Type == Path.PathType.CurveAny || path.Type == Path.PathType.Curve90)
                    {
                        Vector2 v1 = new Vector2(path.StartNode.PosX - path.CornerPosX, path.StartNode.PosY - path.CornerPosY);
                        Vector2 v2 = new Vector2(path.EndNode.PosX - path.CornerPosX, path.EndNode.PosY - path.CornerPosY);
                        Vector2 v12 = new Vector2(path.StartNode.PosX - path.EndNode.PosX, path.StartNode.PosY - path.EndNode.PosY);
                        float check = v12.X * v12.Y;
                        if (check == 0 && path.Type == Path.PathType.Curve90) return;
                        else
                        {
                            var theta = Math.Acos(Vector2.Dot(v1, v2) / (v1.Length() * v2.Length()));
                            var beta = Math.PI / 2 - theta / 2;
                            var l = path.Radius / Math.Cos(beta);
                            var ll = l * Math.Cos(theta / 2);
                            Vector2 v3 = v1 / v1.Length() + v2 / v2.Length();
                            var centerX = path.CornerPosX + v3.X / v3.Length() * l;
                            var centerY = path.CornerPosY + v3.Y / v3.Length() * l;

                            var p1X = path.CornerPosX + v1.X / v1.Length() * ll;
                            var p1Y = path.CornerPosY + v1.Y / v1.Length() * ll;
                            var p2X = path.CornerPosX + v2.X / v2.Length() * ll;
                            var p2Y = path.CornerPosY + v2.Y / v2.Length() * ll;

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
                                startAngle = 2 * Math.PI - startAngle;
                            }


                            graphics.DrawLine(new Pen(Color.Red, 3), path.StartNode.PosX, path.StartNode.PosY, (int)p1X, (int)p1Y);
                            graphics.DrawLine(new Pen(Color.Red, 3), path.EndNode.PosX, path.EndNode.PosY, (int)p2X, (int)p2Y);
                            graphics.FillEllipse(Brushes.Blue, (int)p1X - 5, (int)p1Y - 5, 10, 10);
                            graphics.FillEllipse(Brushes.Purple, (int)p2X - 5, (int)p2Y - 5, 10, 10);
                            graphics.FillEllipse(Brushes.Red, (int)centerX - 5, (int)centerY - 5, 10, 10);
                            //graphics.DrawEllipse(new Pen(Color.Red, 3), (int)(centerX - path.Radius), (int)(centerY - path.Radius), path.Radius * 2, path.Radius * 2);
                            graphics.DrawArc(new Pen(Color.Red, 3), (int)(centerX - path.Radius), (int)(centerY - path.Radius), path.Radius * 2, path.Radius * 2, (int)(startAngle / Math.PI * 180), (int)(sweepAngle / Math.PI * 180));
                        }
                    }
                }
            }
        }
        private void DrawStations()
        {
            using (var graphics = Graphics.FromImage(_picture))
            {
                foreach (var station in _sfc.Stations)
                {         
                    var StationLocationX = station.ReferNode.PosX + station.OffsetX;
                    var StationLocationY = station.ReferNode.PosY + station.OffsetY;
                    if (StationLocationX % _initialgridsize != 0 || StationLocationY % _initialgridsize != 0)
                    {
                        var nearpointx = StationLocationX % _initialgridsize;
                        var nearpointy = StationLocationY % _initialgridsize;
                        StationLocationX -= nearpointx;
                        StationLocationY -= nearpointy;
                    }
                    var size = station.GetStationSize();
                    var width = size.X;
                    var height = size.Y;
                    switch (station.Type)
                    {
                        case Station.StationType.ThreeAxisCNC:
                            graphics.DrawImage(Properties.Resources._3axis_VCP60, new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height)));
                            break;
                        case Station.StationType.FiveAxisCNC:
                            graphics.DrawImage(Properties.Resources._5axis_NFX400a, new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height)));
                            break;
                        case Station.StationType.Rack:
                            graphics.DrawImage(Properties.Resources.stand, new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height)));
                            break;
                        case Station.StationType.WIP:
                            graphics.DrawImage(Properties.Resources.work_in_progress, new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height)));
                            break;
                        case Station.StationType.StorageStation:
                            graphics.DrawImage(Properties.Resources.stock, new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height)));
                            break;
                        case Station.StationType.ChargeStation:
                            graphics.DrawImage(Properties.Resources.charging_station, new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height)));
                            break;
                        default:
                            graphics.DrawIcon(Properties.Resources.workstation, new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height)));//DrawImage
                            break;
                    }

                    if (station == _sfc.SelectedStation)
                    {
                        graphics.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(new Point(StationLocationX - width / 2, StationLocationY - height / 2), new Size(width, height)));
                    }
                }
            }
        }
        private void DrawAGVs()
        {
            using (var graphics = Graphics.FromImage(_picture))
            {
                foreach (var agv in _sfc.AGVs)
                {                    
                    graphics.DrawImage(Properties.Resources.self_driving, new Rectangle(new Point((int)agv.X - _agvSize/2, (int)agv.Y - _agvSize/2), new Size(_agvSize, _agvSize)));
                    if (agv == _sfc.SelectedAGV)
                    {
                        graphics.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(new Point((int)agv.X - _agvSize/2, (int)agv.Y - _agvSize/2), new Size(_agvSize, _agvSize)));
                    }
                }
            }
        }
    }
}

