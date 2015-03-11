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

        private RestClient client;
        private RestRequest request;
        private JsonDeserializer deserial;

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
            this.Intialize();
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
            this.Intialize();
        }

        /// <summary>
        /// Detects images and faces from an image
        /// </summary>
        /// <param name="imageUrl">The location (URI) of the image</param>
        /// <param name="selector">Specify the type of data to receive from HTTP request ("SETPOSE" "FACE", "FULL", "EYES" -- see Kairos Documentation</param>
        /// <returns>The response from the call to /Detect</returns>
        public Kairos.API.DetectResponse Detect(string imageUrl, string selector)
        {
            this.request.Resource = "detect";

            // set request headers
            this.SetHeaders();

            this.request.AddBody(new { image = imageUrl, selector = selector.ToUpper() });

            // Testing
            RestResponse response = (RestResponse)client.Execute(request);
            var content = response.Content;

            // Execute the request
            var requestResponse = client.Execute<DetectResponse>(request);

            // Return the deserialized response
            return this.deserial.Deserialize<DetectResponse>(requestResponse);

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
            this.request.Resource = "enroll";

            // set request headers
            this.SetHeaders();

            // Set the parameters
            // Note using the AddParameter method after using the Addbody method to add content to the HTTP Post, the body will be overridden. 
            this.request.AddBody(new { image = imageUrl, subject_id = subjectId, gallery_name = galleryId, selector = selector.ToUpper() });

            // Execute the request
            var requestResponse = client.Execute<EnrollResponse>(request);

            // testing
            // var content = requestResponse.Content;

            // Return the deserialized response
            return this.deserial.Deserialize<EnrollResponse>(requestResponse);
        }

        /// <summary>
        /// Recognizes a previously detected/enrolled image in the system 
        /// </summary>

        /// <returns>The recognition response with the possible matches</returns>
        public Kairos.API.RecognizeResponse Recognize(string imageUrl, string galleryId)
        {
            this.request.Resource = "recognize";

            // set request headers
            this.SetHeaders();

            // Add request content 
            this.request.AddBody(new { image = imageUrl, gallery_name = galleryId });

            // Execute the request
            var requestResponse = client.Execute<RecognizeResponse>(request);

            // testing
            // var content = requestResponse.Content;

            // Return the deserialized response
            return this.deserial.Deserialize<RecognizeResponse>(requestResponse);
        }

        public Kairos.API.GalleryListResponse ListAll()
        {
            this.request.Resource = "gallery/list_all";

            // set request headers
            this.SetHeaders();

            // Execute the request
            var requestResponse = client.Execute<GalleryListResponse>(this.request);

            // return deserialized data
            return this.deserial.Deserialize<GalleryListResponse>(requestResponse);
        }

        public Kairos.API.GalleryViewResponse View(string galleryId)
        {
            this.request.Resource = "gallery/view";
            // set request headers
            this.SetHeaders();

            // add request body
            this.request.AddBody(new { gallery_id = galleryId });

            // execute request
            var requestResponse = client.Execute<GalleryViewResponse>(this.request);

            return this.deserial.Deserialize<GalleryViewResponse>(requestResponse);
        }

        public void Intialize()
        {
            // create client
            this.client = new RestClient(API_BASE_URL);

            // create request
            this.request = new RestRequest(Method.POST);

            // specify data format
            this.request.RequestFormat = DataFormat.Json;

            // initialize json deserializer
            this.deserial = new JsonDeserializer();
        }

        // Set request headers
        private void SetHeaders()
        {
            this.request.AddHeader("app_id", this._applicationID);
            this.request.AddHeader("app_key", this._applicationKey);
            this.request.AddHeader("Content-Type", "application/json");
        }
    }
}
