gst-launch-1.0 v4l2src device=/dev/video0 ! \
    videoconvert ! \
    video/x-raw,format=I420 ! \
    x265enc tune=zerolatency speed-preset=ultrafast bitrate=2000 ! \
    h265parse ! \
    rtph265pay config-interval=1 mtu=1400 ! \
    rtpstreampay ! \
    udpsink host=127.0.0.1 port=5000 sync=false

#gst-launch-1.0 v4l2src device=/dev/video0 ! videoconvert ! videoscale ! video/x-raw,width=640,height=480,framerate=30/1 ! jpegenc quality=80 ! rtpjpegpay ! udpsink host=127.0.0.1 port=5000

# gst-launch-1.0 v4l2src do-timestamp=true device=/dev/video0 ! \
#             image/jpeg,width=1920,height=1080,framerate=30/1 ! \
#             nvv4l2decoder mjpeg=1 ! nvvidconv ! tee name=t \
#             t. ! queue ! rtpvrawpay ! udpsink host=127.0.0.1 port=20000 sync=false async=false \
#             t. ! queue leaky=downstream max-size-buffers=1 max-size-bytes=0 max-size-time=0 ! videoscale ! \
#             video/x-raw,width=640,height=380,format=I420 ! \
#             nvvidconv ! video/x-raw(memory:NVMM),format=NV12 ! \
#             nvv4l2h265enc preset-level=1 bitrate=4000000 ! \
#             h265parse ! rtph265pay config-interval=1 ! \
#             rtpulpfecenc percentage=30 ! \
#             rtpstreampay ! \
#             tcpserversink host=127.0.0.1 port=5000 sync=false 

#
# gst-launch-1.0 -v \
#   v4l2src device=/dev/video0 ! \
#   videoconvert ! \
#   video/x-raw,format=I420,width=640,height=480,framerate=30/1 ! \
#   x264enc tune=zerolatency speed-preset=ultrafast bitrate=2000 key-int-max=30 ! \
#   h264parse ! \
#   mpegtsmux ! \
#   tcpserversink host=127.0.0.1 port=5000