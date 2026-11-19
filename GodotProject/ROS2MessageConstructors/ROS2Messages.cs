using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages;

public static class Enums
{
  public enum Services {CamParams, HeistMechanismService, LatencySize, NodeInfo, NodeLog, SetCameraInfo, AntennaControlService, SetBool, Trigger, Empty  }
  public static string GetServiceGlobalClassFromEnum(Services service) {
    return service switch {
      Services.CamParams => nameof(rover2_camera_interface.srv.CamParams),
      Services.HeistMechanismService => nameof(rover2_control_interface.srv.HeistMechanismService),
      Services.LatencySize => nameof(rover2_status_interface.srv.LatencySize),
      Services.NodeInfo => nameof(rover2_status_interface.srv.NodeInfo),
      Services.NodeLog => nameof(rover2_status_interface.srv.NodeLog),
      Services.SetCameraInfo => nameof(sensor_msgs.srv.SetCameraInfo),
      Services.AntennaControlService => nameof(std_srvs.srv.AntennaControlService),
      Services.SetBool => nameof(std_srvs.srv.SetBool),
      Services.Trigger => nameof(std_srvs.srv.Trigger),
      Services.Empty => nameof(std_srvs.srv.Empty),
      _ => nameof(BaseRequest)
    };
  }
}