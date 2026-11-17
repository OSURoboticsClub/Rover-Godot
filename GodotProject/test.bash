gst-launch-1.0 -v \
  v4l2src device=/dev/video0 ! \
  videoconvert ! \
  video/x-raw,format=I420,width=640,height=480,framerate=30/1 ! \
  x264enc tune=zerolatency speed-preset=ultrafast bitrate=2000 key-int-max=30 ! \
  h264parse ! \
  mpegtsmux ! \
  tcpserversink host=127.0.0.1 port=5000