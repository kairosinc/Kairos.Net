Kairos.Net
==========

A .NET Wrapper for the Kairos.io Facial Recognition API written in C#.

[![Build status](https://ci.appveyor.com/api/projects/status/gxjuitmsc5p10jof?svg=true)](https://ci.appveyor.com/project/faxedhead/kairos-net)

### License: MIT

### About Kairos.io
For more information and to register for an API key, visit http://Kairos.io.

This library allows you to interact with the http://Kairos.io API for secured cloud-based
facial recognition capabilities.

### Usage
The .NET library allows you to detect, enroll and recognize a face or faces from an image located on the internet.

### Enroll a user

    Kairos.API.KairosClient client = new Kairos.API.KairosClient();

    // Set your credentials
    client.ApplicationID = "your_app_id";
    client.ApplicationKey = "your_app_key";
    
    // Enroll a user
    var response = client.Enroll("http://localhost/myimage.jpg", "myuserid");

### Recognize a user

    Kairos.API.KairosClient client = new Kairos.API.KairosClient();

    // Set your credentials
    client.ApplicationID = "your_app_id";
    client.ApplicationKey = "your_app_key";
    
    // Attempt user recognition
    var recognizeResponse = client.Recognize("http://localhost/myimage.jpg");

    // Get the recognized user ID
    var userID = recognizeResponse.Images[0].Candidates.First().Key;  
    
### Detect faces

    Kairos.API.KairosClient client = new Kairos.API.KairosClient();

    // Set your credentials
    client.ApplicationID = "your_app_id";
    client.ApplicationKey = "your_app_key";
    
    // Detect the face(s)
    var detectResponse = client.Detect("http://wellness.18signals.com/kairos.jpg");
    
    // Get the image and information on the first recognized face
    var detectedImage = detectResponse.Images[0];
    var face = detectedImage.Faces[0];

### Meta
Thanks to Cole Calistra and Brian Brackeen
