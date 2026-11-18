import sys
if sys.prefix == '/usr':
    sys.real_prefix = sys.prefix
    sys.prefix = sys.exec_prefix = '/home/mocha/Rover-Godot/godot_udp_ros_bridge/install/unity_udp_ros_bridge'
