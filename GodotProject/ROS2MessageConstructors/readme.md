Because it is difficult to create universally reusable code when we are trying to send very different Ros2 Json messages, we use a script to build CSharp classes from these Json messages that we are able to edit the values of in the editor. This allows us to have one script for "SendRos2Service Button" instead of needing to hand write a new script each time

The python script "buildCsFromJson.py" will automattically generate these CSharp classes from the Json file
For this to work you need to make sure that if the Json is a service, it is put in a folder named "srv", and likewise, "msg" for messages (you also cant nest folders in a folder named "srv" or "msg")
Then, run the python script, and it will automatically regerate the code, so that you can use your message in godot