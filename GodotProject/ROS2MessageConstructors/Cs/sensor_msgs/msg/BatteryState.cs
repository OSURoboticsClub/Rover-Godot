using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class BatteryState : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/BatteryState\",\"data\":{\"POWER_SUPPLY_STATUS_UNKNOWN\":0,\"POWER_SUPPLY_STATUS_CHARGING\":0,\"POWER_SUPPLY_STATUS_DISCHARGING\":0,\"POWER_SUPPLY_STATUS_NOT_CHARGING\":0,\"POWER_SUPPLY_STATUS_FULL\":0,\"POWER_SUPPLY_HEALTH_UNKNOWN\":0,\"POWER_SUPPLY_HEALTH_GOOD\":0,\"POWER_SUPPLY_HEALTH_OVERHEAT\":0,\"POWER_SUPPLY_HEALTH_DEAD\":0,\"POWER_SUPPLY_HEALTH_OVERVOLTAGE\":0,\"POWER_SUPPLY_HEALTH_UNSPEC_FAILURE\":0,\"POWER_SUPPLY_HEALTH_COLD\":0,\"POWER_SUPPLY_HEALTH_WATCHDOG_TIMER_EXPIRE\":0,\"POWER_SUPPLY_HEALTH_SAFETY_TIMER_EXPIRE\":0,\"POWER_SUPPLY_TECHNOLOGY_UNKNOWN\":0,\"POWER_SUPPLY_TECHNOLOGY_NIMH\":0,\"POWER_SUPPLY_TECHNOLOGY_LION\":0,\"POWER_SUPPLY_TECHNOLOGY_LIPO\":0,\"POWER_SUPPLY_TECHNOLOGY_LIFE\":0,\"POWER_SUPPLY_TECHNOLOGY_NICD\":0,\"POWER_SUPPLY_TECHNOLOGY_LIMN\":0,\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"voltage\":0.0,\"temperature\":0.0,\"current\":0.0,\"charge\":0.0,\"capacity\":0.0,\"design_capacity\":0.0,\"percentage\":0.0,\"power_supply_status\":0,\"power_supply_health\":0,\"power_supply_technology\":0,\"present\":false,\"cell_voltage\":[],\"cell_temperature\":[],\"location\":\"\",\"serial_number\":\"\"}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int POWER_SUPPLY_STATUS_UNKNOWN{get; set; }= 0;
  [Export] public int POWER_SUPPLY_STATUS_CHARGING{get; set; }= 0;
  [Export] public int POWER_SUPPLY_STATUS_DISCHARGING{get; set; }= 0;
  [Export] public int POWER_SUPPLY_STATUS_NOT_CHARGING{get; set; }= 0;
  [Export] public int POWER_SUPPLY_STATUS_FULL{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_UNKNOWN{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_GOOD{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_OVERHEAT{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_DEAD{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_OVERVOLTAGE{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_UNSPEC_FAILURE{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_COLD{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_WATCHDOG_TIMER_EXPIRE{get; set; }= 0;
  [Export] public int POWER_SUPPLY_HEALTH_SAFETY_TIMER_EXPIRE{get; set; }= 0;
  [Export] public int POWER_SUPPLY_TECHNOLOGY_UNKNOWN{get; set; }= 0;
  [Export] public int POWER_SUPPLY_TECHNOLOGY_NIMH{get; set; }= 0;
  [Export] public int POWER_SUPPLY_TECHNOLOGY_LION{get; set; }= 0;
  [Export] public int POWER_SUPPLY_TECHNOLOGY_LIPO{get; set; }= 0;
  [Export] public int POWER_SUPPLY_TECHNOLOGY_LIFE{get; set; }= 0;
  [Export] public int POWER_SUPPLY_TECHNOLOGY_NICD{get; set; }= 0;
  [Export] public int POWER_SUPPLY_TECHNOLOGY_LIMN{get; set; }= 0;
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public double voltage{get; set; }= 0.0;
  [Export] public double temperature{get; set; }= 0.0;
  [Export] public double current{get; set; }= 0.0;
  [Export] public double charge{get; set; }= 0.0;
  [Export] public double capacity{get; set; }= 0.0;
  [Export] public double design_capacity{get; set; }= 0.0;
  [Export] public double percentage{get; set; }= 0.0;
  [Export] public int power_supply_status{get; set; }= 0;
  [Export] public int power_supply_health{get; set; }= 0;
  [Export] public int power_supply_technology{get; set; }= 0;
  [Export] public bool present{get; set; }= false;
  [Export] public string cell_voltage{get; set; }= "";
  [Export] public string cell_temperature{get; set; }= "";
  [Export] public string location{get; set; }= "";
  [Export] public string serial_number{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["POWER_SUPPLY_STATUS_UNKNOWN"] = POWER_SUPPLY_STATUS_UNKNOWN;
    returnValue["data"]["POWER_SUPPLY_STATUS_CHARGING"] = POWER_SUPPLY_STATUS_CHARGING;
    returnValue["data"]["POWER_SUPPLY_STATUS_DISCHARGING"] = POWER_SUPPLY_STATUS_DISCHARGING;
    returnValue["data"]["POWER_SUPPLY_STATUS_NOT_CHARGING"] = POWER_SUPPLY_STATUS_NOT_CHARGING;
    returnValue["data"]["POWER_SUPPLY_STATUS_FULL"] = POWER_SUPPLY_STATUS_FULL;
    returnValue["data"]["POWER_SUPPLY_HEALTH_UNKNOWN"] = POWER_SUPPLY_HEALTH_UNKNOWN;
    returnValue["data"]["POWER_SUPPLY_HEALTH_GOOD"] = POWER_SUPPLY_HEALTH_GOOD;
    returnValue["data"]["POWER_SUPPLY_HEALTH_OVERHEAT"] = POWER_SUPPLY_HEALTH_OVERHEAT;
    returnValue["data"]["POWER_SUPPLY_HEALTH_DEAD"] = POWER_SUPPLY_HEALTH_DEAD;
    returnValue["data"]["POWER_SUPPLY_HEALTH_OVERVOLTAGE"] = POWER_SUPPLY_HEALTH_OVERVOLTAGE;
    returnValue["data"]["POWER_SUPPLY_HEALTH_UNSPEC_FAILURE"] = POWER_SUPPLY_HEALTH_UNSPEC_FAILURE;
    returnValue["data"]["POWER_SUPPLY_HEALTH_COLD"] = POWER_SUPPLY_HEALTH_COLD;
    returnValue["data"]["POWER_SUPPLY_HEALTH_WATCHDOG_TIMER_EXPIRE"] = POWER_SUPPLY_HEALTH_WATCHDOG_TIMER_EXPIRE;
    returnValue["data"]["POWER_SUPPLY_HEALTH_SAFETY_TIMER_EXPIRE"] = POWER_SUPPLY_HEALTH_SAFETY_TIMER_EXPIRE;
    returnValue["data"]["POWER_SUPPLY_TECHNOLOGY_UNKNOWN"] = POWER_SUPPLY_TECHNOLOGY_UNKNOWN;
    returnValue["data"]["POWER_SUPPLY_TECHNOLOGY_NIMH"] = POWER_SUPPLY_TECHNOLOGY_NIMH;
    returnValue["data"]["POWER_SUPPLY_TECHNOLOGY_LION"] = POWER_SUPPLY_TECHNOLOGY_LION;
    returnValue["data"]["POWER_SUPPLY_TECHNOLOGY_LIPO"] = POWER_SUPPLY_TECHNOLOGY_LIPO;
    returnValue["data"]["POWER_SUPPLY_TECHNOLOGY_LIFE"] = POWER_SUPPLY_TECHNOLOGY_LIFE;
    returnValue["data"]["POWER_SUPPLY_TECHNOLOGY_NICD"] = POWER_SUPPLY_TECHNOLOGY_NICD;
    returnValue["data"]["POWER_SUPPLY_TECHNOLOGY_LIMN"] = POWER_SUPPLY_TECHNOLOGY_LIMN;
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["voltage"] = voltage;
    returnValue["data"]["temperature"] = temperature;
    returnValue["data"]["current"] = current;
    returnValue["data"]["charge"] = charge;
    returnValue["data"]["capacity"] = capacity;
    returnValue["data"]["design_capacity"] = design_capacity;
    returnValue["data"]["percentage"] = percentage;
    returnValue["data"]["power_supply_status"] = power_supply_status;
    returnValue["data"]["power_supply_health"] = power_supply_health;
    returnValue["data"]["power_supply_technology"] = power_supply_technology;
    returnValue["data"]["present"] = present;
    returnValue["data"]["cell_voltage"] = cell_voltage;
    returnValue["data"]["cell_temperature"] = cell_temperature;
    returnValue["data"]["location"] = location;
    returnValue["data"]["serial_number"] = serial_number;
    return  returnValue;
  }
  public override BatteryState loadJson(JObject json) {
    POWER_SUPPLY_STATUS_UNKNOWN = (int)json["data"]["POWER_SUPPLY_STATUS_UNKNOWN"];
    POWER_SUPPLY_STATUS_CHARGING = (int)json["data"]["POWER_SUPPLY_STATUS_CHARGING"];
    POWER_SUPPLY_STATUS_DISCHARGING = (int)json["data"]["POWER_SUPPLY_STATUS_DISCHARGING"];
    POWER_SUPPLY_STATUS_NOT_CHARGING = (int)json["data"]["POWER_SUPPLY_STATUS_NOT_CHARGING"];
    POWER_SUPPLY_STATUS_FULL = (int)json["data"]["POWER_SUPPLY_STATUS_FULL"];
    POWER_SUPPLY_HEALTH_UNKNOWN = (int)json["data"]["POWER_SUPPLY_HEALTH_UNKNOWN"];
    POWER_SUPPLY_HEALTH_GOOD = (int)json["data"]["POWER_SUPPLY_HEALTH_GOOD"];
    POWER_SUPPLY_HEALTH_OVERHEAT = (int)json["data"]["POWER_SUPPLY_HEALTH_OVERHEAT"];
    POWER_SUPPLY_HEALTH_DEAD = (int)json["data"]["POWER_SUPPLY_HEALTH_DEAD"];
    POWER_SUPPLY_HEALTH_OVERVOLTAGE = (int)json["data"]["POWER_SUPPLY_HEALTH_OVERVOLTAGE"];
    POWER_SUPPLY_HEALTH_UNSPEC_FAILURE = (int)json["data"]["POWER_SUPPLY_HEALTH_UNSPEC_FAILURE"];
    POWER_SUPPLY_HEALTH_COLD = (int)json["data"]["POWER_SUPPLY_HEALTH_COLD"];
    POWER_SUPPLY_HEALTH_WATCHDOG_TIMER_EXPIRE = (int)json["data"]["POWER_SUPPLY_HEALTH_WATCHDOG_TIMER_EXPIRE"];
    POWER_SUPPLY_HEALTH_SAFETY_TIMER_EXPIRE = (int)json["data"]["POWER_SUPPLY_HEALTH_SAFETY_TIMER_EXPIRE"];
    POWER_SUPPLY_TECHNOLOGY_UNKNOWN = (int)json["data"]["POWER_SUPPLY_TECHNOLOGY_UNKNOWN"];
    POWER_SUPPLY_TECHNOLOGY_NIMH = (int)json["data"]["POWER_SUPPLY_TECHNOLOGY_NIMH"];
    POWER_SUPPLY_TECHNOLOGY_LION = (int)json["data"]["POWER_SUPPLY_TECHNOLOGY_LION"];
    POWER_SUPPLY_TECHNOLOGY_LIPO = (int)json["data"]["POWER_SUPPLY_TECHNOLOGY_LIPO"];
    POWER_SUPPLY_TECHNOLOGY_LIFE = (int)json["data"]["POWER_SUPPLY_TECHNOLOGY_LIFE"];
    POWER_SUPPLY_TECHNOLOGY_NICD = (int)json["data"]["POWER_SUPPLY_TECHNOLOGY_NICD"];
    POWER_SUPPLY_TECHNOLOGY_LIMN = (int)json["data"]["POWER_SUPPLY_TECHNOLOGY_LIMN"];
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    voltage = (double)json["data"]["voltage"];
    temperature = (double)json["data"]["temperature"];
    current = (double)json["data"]["current"];
    charge = (double)json["data"]["charge"];
    capacity = (double)json["data"]["capacity"];
    design_capacity = (double)json["data"]["design_capacity"];
    percentage = (double)json["data"]["percentage"];
    power_supply_status = (int)json["data"]["power_supply_status"];
    power_supply_health = (int)json["data"]["power_supply_health"];
    power_supply_technology = (int)json["data"]["power_supply_technology"];
    present = (bool)json["data"]["present"];
    cell_voltage = (string)json["data"]["cell_voltage"];
    cell_temperature = (string)json["data"]["cell_temperature"];
    location = (string)json["data"]["location"];
    serial_number = (string)json["data"]["serial_number"];
    return  this;
  }
  public static explicit operator BatteryState(JObject json){
    return new BatteryState().loadJson(json);
  }
  BatteryState() {}
}
