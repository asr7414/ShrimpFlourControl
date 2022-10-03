using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MySql.Data;               // Install from nuget extension manager+
using MySql.Data.MySqlClient;
using ShrimpFlourControl.Maps;
using ShrimpFlourControl.Vehicles;
using ShrimpFlourControl.Stations;
using ShrimpFlourControl.Missions;
using System.Data;

namespace ShrimpFlourControl.Communications
{
    public class Database
    {

        private const string dbHost = "140.112.16.7";       // Database Hostname or IP
        private const string dbPort = "13306";                // Database Port (default is 3306)
        private const string dbUser = "mes";                 // Database Username
        private const string dbPass = "0979579729";             // Database Password
        private const string dbName = "db_MES_2";                   // Database Name
        private string connStr = "server=" + dbHost + ";port=" + dbPort + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
        private const string sqlStringPath = "SELECT * FROM `Path` WHERE 1";
        private const string sqlStringAGV = "SELECT * FROM `AGV` WHERE 1";
        private const string sqlStringStation = "SELECT * FROM `Stations` WHERE 1";

        private MySqlConnection _mySqlConnection;       // go check naming convention

        public bool IsConnected
        {
            get
            {
                return _mySqlConnection.State == System.Data.ConnectionState.Open;
            }
        }

        public Database()
        {
            _mySqlConnection = new MySqlConnection();
        }


        public bool Connect()
        {
            _mySqlConnection.ConnectionString = connStr;
            try
            {
                _mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            if (_mySqlConnection.State == System.Data.ConnectionState.Open)
            {
                return true;
            }

            return false;
        }

        public List<Mission> GetAllMissions()
        {
            const string sqlString = "SELECT * FROM `ProductionStation` WHERE 1";
            MySqlCommand sqlCmd = new MySqlCommand(sqlString, _mySqlConnection);
            MySqlDataReader dataReader = sqlCmd.ExecuteReader();
            List<Mission> list = new List<Mission>();
            
            try
            {
                var oldProductId = 0;
                while (dataReader.Read())
                {
                    var ProductId = dataReader.GetInt32(0);
                    var StationId = dataReader.GetInt32(1);
                    var StationProcessTime = dataReader.GetInt32(2);
                    if (oldProductId != ProductId)
                    {
                        Mission mission = new Mission()
                        {
                            Id = ProductId,
                        };
                        //mission.StationRouter.Add()

                        list.Add(mission);
                    }
                    else
                    {

                    }
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                dataReader.Close();
            }

            return list;
        }

        public List<Node> GetAllNodes()
        {
            const string sqlString = "SELECT * FROM `Node` WHERE 1";
            MySqlCommand sqlCmd = new MySqlCommand(sqlString, _mySqlConnection);
            MySqlDataReader dataReader = sqlCmd.ExecuteReader();
            List<Node> nodeList = new List<Node>();

            try
            {
                while (dataReader.Read())
                {
                    var nodeID = dataReader.GetInt32(0);
                    var posX = dataReader.GetInt32(1);
                    var posY = dataReader.GetInt32(2);
                    var newNode = new Node(nodeID, posX, posY);
                    nodeList.Add(newNode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                dataReader.Close();
            }

            return nodeList;
        }

        public List<AGV> GetAllAGVs(List<Node> refererNodes)
        {
            const string sqlString = "SELECT * FROM `AGV` WHERE 1";
            MySqlCommand sqlCmd = new MySqlCommand(sqlString, _mySqlConnection);
            MySqlDataReader dataReader = sqlCmd.ExecuteReader();
            List<AGV> agvList = new List<AGV>();

            try
            {
                while (dataReader.Read())
                {
                    var agvID = dataReader.GetInt32(0);
                    var currentNodeID = dataReader.GetInt32(1);
                    var currentNode = refererNodes.FirstOrDefault(node => node.ID == currentNodeID);            // LINQ lambda
                    if (currentNode != null)
                    {
                        var newAGV = new SimulatedAGV(agvID, currentNode);
                        agvList.Add(newAGV);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                dataReader.Close();
            }
            return agvList;
        }

        public List<Path> GetAllPaths(List<Node> refererNodes)
        {
            const string sqlString = "SELECT * FROM `Path` WHERE 1";
            MySqlCommand sqlCmd = new MySqlCommand(sqlString, _mySqlConnection);
            MySqlDataReader dataReader = sqlCmd.ExecuteReader();
            List<Path> pathList = new List<Path>();

            try
            {
                while (dataReader.Read())
                {
                    var pathID = dataReader.GetInt32(0);
                    var type = dataReader.GetInt32(1);
                    var startNodeID = dataReader.GetInt32(2);
                    var endNodeID = dataReader.GetInt32(3);
                    var cornerPosX = dataReader.GetInt32(4);
                    var cornerPosY = dataReader.GetInt32(5);
                    var radius = dataReader.GetInt32(6);
                    var direction = dataReader.GetInt32(7);
                    var startNode = refererNodes.FirstOrDefault(node => node.ID == startNodeID);            // LINQ lambda
                    var endNode = refererNodes.FirstOrDefault(node => node.ID == endNodeID);            // LINQ lambda
                    if (startNode != null && endNode != null)
                    {
                        var newPath = new Path(pathID, startNode, endNode, (Path.PathType)type, cornerPosX, cornerPosY, radius, (Path.PathDirection)direction);
                        pathList.Add(newPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                dataReader.Close();
            }

            return pathList;
        }

        public List<Station> GetAllStations(List<Node> refererNodes)
        {
            const string sqlString = "SELECT * FROM `Station` WHERE 1";
            MySqlCommand sqlCmd = new MySqlCommand(sqlString, _mySqlConnection);
            MySqlDataReader dataReader = sqlCmd.ExecuteReader();
            List<Station> stationList = new List<Station>();

            try
            {
                while (dataReader.Read())
                {
                    var pathID = dataReader.GetInt32(0);
                    var type = dataReader.GetInt32(1);
                    var refererNodeID = dataReader.GetInt32(2);
                    var offsetX = dataReader.GetInt32(3);
                    var offsetY = dataReader.GetInt32(4);
                    var refererNode = refererNodes.FirstOrDefault(node => node.ID == refererNodeID);
                    if (refererNode != null)
                    {
                        Station newStation = null;
                        switch ((Station.StationType)type)
                        {
                            case Station.StationType.FiveAxisCNC:                                
                                newStation = new FiveAxisCNC(pathID, refererNode, offsetX, offsetY);
                                break;
                            case Station.StationType.ChargeStation:
                                newStation = new ChargeStation(pathID, refererNode, offsetX, offsetY);
                                break;
                            case Station.StationType.Rack:
                                newStation = new Rack(pathID, refererNode, offsetX, offsetY);
                                break;
                            case Station.StationType.StorageStation:
                                newStation = new StorageStation(pathID, refererNode, offsetX, offsetY);
                                break;
                            case Station.StationType.ThreeAxisCNC:
                                newStation = new ThreeAxisCNC(pathID, refererNode, offsetX, offsetY);
                                break;
                            case Station.StationType.WIP:
                                newStation = new WIP(pathID, refererNode, offsetX, offsetY);
                                break;
                        }
                        if (newStation != null)
                        {
                            stationList.Add(newStation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                dataReader.Close();
            }

            return stationList;
        }

        public bool SaveAllNodes(List<Node> nodeList)
        {
            MySqlCommand sqlCmd;
            try
            {
                foreach (var node in nodeList)
                {
                    string queryString = $"INSERT INTO `Node`(`ID`, `PosX`, `PosY`) VALUES('{node.ID}','{node.PosX}','{node.PosY}')";
                    sqlCmd = new MySqlCommand(queryString, _mySqlConnection);
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public bool SaveAllAGVs(List<AGV> agvList)
        {
            MySqlCommand sqlCmd;
            try
            {
                foreach (var agv in agvList)
                {
                    string queryString = $"INSERT INTO `AGV`(`ID`, `NodeID`) VALUES('{agv.ID}','{agv.CurrentNode.ID}')";
                    sqlCmd = new MySqlCommand(queryString, _mySqlConnection);
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public bool SaveAllPaths(List<Path> pathList)
        {
            MySqlCommand sqlCmd;
            try
            {
                foreach (var path in pathList)
                {
                    string queryString = $"INSERT INTO `Path`(`ID`, `Type`, `StartNodeID`, `EndNodeID`, `CornerPosX`, `CornerPosY`, `Radius`, `Direction`) " +
                        $"VALUES ('{path.ID}','{(int)path.Type}','{path.StartNode.ID}','{path.EndNode.ID}','{path.CornerPosX}','{path.CornerPosY}','{path.Radius}','{(int)path.Direction}')";
                    sqlCmd = new MySqlCommand(queryString, _mySqlConnection);
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public bool SaveAllStations(List<Station> stationList)
        {
            MySqlCommand sqlCmd;
            try
            {
                foreach (var station in stationList)
                {
                    string queryString = $"INSERT INTO `Station`(`ID`, `Type`, `RefererNodeID`, `OffsetX`, `OffsetY`) " +
                        $"VALUES ('{station.ID}','{(int)station.Type}','{station.ReferNode.ID}','{station.OffsetX}','{station.OffsetY}')";
                    sqlCmd = new MySqlCommand(queryString, _mySqlConnection);
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public bool ClearAllMDFKTables()
        {
            string[] queryStrings = { "TRUNCATE TABLE `Station`", "TRUNCATE TABLE `AGV`", "TRUNCATE TABLE `Node`", "TRUNCATE TABLE `Path`" };

            MySqlCommand sqlCMD;

            try
            {
                for (int i = 0; i < queryStrings.Length; i++)
                {
                    sqlCMD = new MySqlCommand(queryStrings[i], _mySqlConnection);
                    sqlCMD.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error occured when TRUNCATE a 奶酪: {ex.Message}");
                return false;
            }
            return true;
        }

    }
}
