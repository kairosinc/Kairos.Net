/*************************************************************************
* 
* 18 SIGNALS CONFIDENTIAL
* __________________
* 
*  [2013] 18 SIGNALS, LLC
*  All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains
* the property of 18 SIGNALS, LLC and its suppliers,
* if any.  The intellectual and technical concepts contained
* herein are proprietary to 18 SIGNALS, LLC and its suppliers 
* and may be covered by U.S. and Foreign Patents, patents in process, 
* and are protected by trade secret or copyright law.
* Dissemination of this information or reproduction of this material
* is strictly forbidden unless prior written permission is obtained
* from 18 SIGNALS, LLC.
*/

using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.API
{
    /// <summary>
    /// Wrapper class responsible for making call to the Kairos API
    /// </summary>
    public class KairosClient
    {
        private const string API_BASE_URL = "http://api.kairos.io";

        private string _applicationID { get; set; }
        private string _applicationKey { get; set; }

        /// <summary>
        /// The application ID
        /// </summary>
        public string ApplicationID 
        {
            get { return this._applicationID; }
            set { this._applicationID = value; } 
        }
        
        /// <summary>
        /// The application key
        /// </summary>
        public string ApplicationKey         
        {
            get { return this._applicationKey; }
            set { this._applicationKey = value; }
        }

        /// <summary>
        /// Our default constructor taking the application ID and application key as parameters
        /// </summary>
        public KairosClient()
        {
            // Initialize internal members
            this._applicationID = null;
            this._applicationKey = null;
        }

        /// <summary>
        /// Our default constructor taking the application ID and application key as parameters
        /// </summary>
        /// <param name="applicationId">The Kairos application ID</param>
        /// <param name="applicationKey">The Kairos application Key</param>
        public KairosClient(string applicationId, string applicationKey)
        {
            // Initialize internal members
            this._applicationID = applicationId;
            this._applicationKey = applicationKey;
        }

        /// <summary>
        /// Detects images and faces from an image
        /// </summary>
        /// <param name="imageUrl">The location (URI) of the image</param>
        /// <param name="selector">Specify the type of data to receive from HTTP request ("SETPOSE" "FACE", "FULL", "EYES" -- see Kairos Documentation</param>
        /// <returns>The response from the call to /Detect</returns>
        public Kairos.API.DetectResponse Detect(string imageUrl, string selector)
        {
            var client = new RestClient(API_BASE_URL);
            
            var request = new RestRequest("detect", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // Set the parameters
            // request.AddParameter("image", imageUrl);
            // request.AddParameter("selector", "SETPOSE");
            request.AddHeader("app_id", this._applicationID);
            request.AddHeader("app_key", this._applicationKey);
            request.AddHeader("Content-Type", "application/json");

            request.AddBody(new { image = imageUrl, selector = selector.ToUpper() });

            // Specify the content type expected before desiarializing the object
            // request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            
            // Testing
            // RestResponse response = (RestResponse) client.Execute(request);
            // var content = response.Content;

            // Execute the request
            var requestResponse = client.Execute<DetectResponse>(request);

            if (!requestResponse.ContentType.Equals("application/json") || requestResponse.Content.Equals(""))
                return null;

            JsonDeserializer deserial = new JsonDeserializer();

            // Return the deserialized response
            return deserial.Deserialize<DetectResponse>(requestResponse);
           
        }

        /// <summary>
        /// Enrolls a previously detected image into the system by sending an image and specifying a subject and gallery id
        /// </summary>
        /// <param name="imageUrl">The ID of the image previously detected</param>
        /// <param name="subjectId">The tracking ID of the user for which the image is being enrolled</param>
        /// <param name="galleryId">the tracking ID of the gallery for which the image is being enrolled</param>
        /// <param name="selector">Specify the type of data returned by the post request</param>
        /// <returns></returns>
        public Kairos.API.EnrollResponse Enroll(string imageUrl, string subjectId, string galleryId, string selector)
        {
            var client = new RestClient(API_BASE_URL);
            
            var request = new RestRequest("enroll", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // Add request headers
            request.AddHeader("app_id", this._applicationID);
            request.AddHeader("app_key", this._applicationKey);
            request.AddHeader("Content-Type", "application/json");
            
            // Set the parameters
            // Note using the AddParameter method after using the Addbody method to add content to the HTTP Post, the body will be overridden. 
            request.AddBody(new { image = imageUrl, subject_id = subjectId, gallery_name = galleryId, selector = selector.ToUpper() } );

            // testing
            // var response = client.Execute(request);
            // var stuff = response.Content;
            // var content = requestResponse.Content;

            // Execute the request
            var requestResponse = client.Execute<EnrollResponse>(request);

            // testing
            // var content = requestResponse.Content;

            if (!requestResponse.ContentType.Equals("application/json") || requestResponse.Content.Equals(""))
                return null;

            // Json Deserializer
            JsonDeserializer deserial = new JsonDeserializer();

            // Return the deserialized response
            return deserial.Deserialize<EnrollResponse>(requestResponse);
        }

        /// <summary>
        /// Recognizes a previously detected/enrolled image in the system 
        /// </summary>

        /// <returns>The recognition response with the possible matches</returns>
        public Kairos.API.RecognizeResponse Recognize(string imageUrl, string galleryId)
        {
            var client = new RestClient(API_BASE_URL);

            var request = new RestRequest("recognize", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // Set request headers
            request.AddHeader("app_id", this._applicationID);
            request.AddHeader("app_key", this._applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // Add request content 
            request.AddBody(new { image = imageUrl, gallery_name = galleryId });

            // Execute the request
            var requestResponse = client.Execute<RecognizeResponse>(request);

            // testing
            // var content = requestResponse.Content;

            if (!requestResponse.ContentType.Equals("application/json") || requestResponse.Content.Equals(""))
                return null;
            
            // Json Deserializer
            JsonDeserializer deserial = new JsonDeserializer();

            // Return the deserialized response
            return deserial.Deserialize<RecognizeResponse>(requestResponse);
        }

        public Kairos.API.GalleryListResponse ListAll()
        {
            var client = new RestClient(API_BASE_URL);

            var request = new RestRequest("gallery/list_all", Method.POST);

            request.RequestFormat = DataFormat.Json;

            // Set request headers
            request.AddHeader("app_id", this._applicationID);
            request.AddHeader("app_key", this._applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // Execute the request
            var requestResponse = client.Execute<GalleryListResponse>(request);

            // Json Deserializer
            JsonDeserializer deserial = new JsonDeserializer();

            // return deserialized data
            return deserial.Deserialize<GalleryListResponse>(requestResponse);
        }

        public Kairos.API.GalleryViewResponse View(string galleryId)
        {
            // create client
            var client = new RestClient(API_BASE_URL);

            // create request
            var request = new RestRequest("gallery/view", Method.POST);

            // specify data format
            request.RequestFormat = DataFormat.Json;

            // Set request headers
            request.AddHeader("app_id", this._applicationID);
            request.AddHeader("app_key", this._applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // add request body
            request.AddBody(new { gallery_id = galleryId });

            // execute request
            var requestResponse = client.Execute<GalleryViewResponse>(request);

            // create Json Deserializer
            JsonDeserializer deserial = new JsonDeserializer();

            return deserial.Deserialize<GalleryViewResponse>(requestResponse);
        }
    }
}
