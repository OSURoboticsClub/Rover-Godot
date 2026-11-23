gst-launch-1.0 -v v4l2src device=/dev/video0 ! \
    video/x-raw,width=640,height=480,framerate=30/1 ! videoconvert !\
    capsfilter caps=video/x-raw,format=BGR ! \
    videoconvert ! \
    tee name=t \
    t. ! queue max-size-buffers=2 max-size-bytes=0 max-size-time=0 leaky=downstream ! \
    rtpvrawpay ! udpsink host=127.0.0.1 port=20000 sync=false async=false \
    t. ! queue max-size-buffers=2 max-size-bytes=0 max-size-time=0 leaky=downstream ! \
    videoscale ! video/x-raw,width=640,height=480 ! \
    videoconvert ! video/x-raw,format=I420 ! \
    x265enc tune=zerolatency speed-preset=ultrafast \
    bitrate=4000 key-int-max=30 ! \
    h265parse ! rtph265pay config-interval=1 ! \
    rtpulpfecenc percentage=30 ! \
    rtpstreampay ! \
    tcpserversink host=127.0.0.1 port=42069 sync=false