using System.Runtime.Serialization;
using RestSharp;
using RestSharp.Deserializers;

namespace Kairos.Net
{
    /// <summary>
    ///     Wrapper class responsible for making call to the Kairos API
    /// </summary>
    public class KairosClient
    {
        private const string API_BASE_URL = "https://api.kairos.com";

        /// <summary>
        ///     Our default constructor taking the application ID and application key as parameters
        /// </summary>
        public KairosClient()
        {
            // Initialize internal members
            _applicationID = null;
            _applicationKey = null;
        }

        /// <summary>
        ///     Our default constructor taking the application ID and application key as parameters
        /// </summary>
        /// <param name="applicationId">The Kairos application ID</param>
        /// <param name="applicationKey">The Kairos application Key</param>
        public KairosClient(string applicationId, string applicationKey)
        {
            // Initialize internal members
            _applicationID = applicationId;
            _applicationKey = applicationKey;
        }

        private string _applicationID { get; set; }
        private string _applicationKey { get; set; }

        /// <summary>
        ///     The application ID
        /// </summary>
        public string ApplicationID
        {
            get { return _applicationID; }
            set { _applicationID = value; }
        }

        /// <summary>
        ///     The application key
        /// </summary>
        public string ApplicationKey
        {
            get { return _applicationKey; }
            set { _applicationKey = value; }
        }

        /// <summary>
        ///     Detects images and faces from an image
        /// </summary>
        /// <param name="imageUrl">The location (URI) of the image</param>
        /// <param name="selector">
        ///     Specify the type of data to receive from HTTP request ("SETPOSE" "FACE", "FULL", "EYES" -- see
        ///     Kairos Documentation
        /// </param>
        /// <returns>The response from the call to /Detect</returns>
        public DetectResponse Detect(string imageUrl, string selector)
        {
            // create client
            var client = new RestClient(API_BASE_URL);

            // create request
            var request = new RestRequest(Method.POST);

            // specify request resource
            request.Resource = "detect";

            // specify data format
            request.RequestFormat = DataFormat.Json;

            // set request headers
            request.AddHeader("app_id", _applicationID);
            request.AddHeader("app_key", _applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // initialize json deserializer
            var deserial = new JsonDeserializer();

            request.AddBody(new {image = imageUrl, selector = selector.ToUpper()});

            // Testing
            var response = client.Execute(request);
            var content = response.Content;
            var encoding = response.ContentEncoding;

            // Execute the request
            var requestResponse = client.Execute<DetectResponse>(request);

            try
            {
                // Return the deserialized response
                return deserial.Deserialize<DetectResponse>(requestResponse);
            }
            catch (SerializationException)
            {
                throw new SerializationException("Error serializing JSON string. JSON string: " +
                                                 requestResponse.Content);
            }
        }

        /// <summary>
        ///     Detects faces from an image using Kairos' default selector
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public DetectResponse Detect(string imageUrl)
        {
            // create client
            var client = new RestClient(API_BASE_URL);

            // create request
            var request = new RestRequest(Method.POST);

            // specify request resource
            request.Resource = "detect";

            // specify data format
            request.RequestFormat = DataFormat.Json;

            // set request headers
            request.AddHeader("app_id", _applicationID);
            request.AddHeader("app_key", _applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // initialize json deserializer
            var deserial = new JsonDeserializer();

            request.AddBody(new {image = imageUrl});

            // Testing
            // RestResponse response = (RestResponse)client.Execute(request);
            // var content = response.Content;

            // Execute the request
            var requestResponse = client.Execute<DetectResponse>(request);

            try
            {
                // Return the deserialized response
                return deserial.Deserialize<DetectResponse>(requestResponse);
            }
            catch (SerializationException)
            {
                throw new SerializationException("Error serializing JSON string. JSON string: " +
                                                 requestResponse.Content);
            }
        }

        /// <summary>
        ///     Enrolls a previously detected image into the system by sending an image and specifying a subject and gallery id
        /// </summary>
        /// <param name="imageUrl">The ID of the image previously detected</param>
        /// <param name="subjectId">The tracking ID of the user for which the image is being enrolled</param>
        /// <param name="galleryId">the tracking ID of the gallery for which the image is being enrolled</param>
        /// <param name="selector">Specify the type of data returned by the post request</param>
        /// <returns></returns>
        public EnrollResponse Enroll(string imageUrl, string subjectId, string galleryId, string selector)
        {
            // create client
            var client = new RestClient(API_BASE_URL);

            // create request
            var request = new RestRequest(Method.POST);

            // specify request resource
            request.Resource = "enroll";

            // specify data format
            request.RequestFormat = DataFormat.Json;

            // set request headers
            request.AddHeader("app_id", _applicationID);
            request.AddHeader("app_key", _applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // initialize json deserializer
            var deserial = new JsonDeserializer();

            // Set the parameters
            // Note using the AddParameter method after using the Addbody method to add content to the HTTP Post, the body will be overridden. 
            request.AddBody(
                new {image = imageUrl, subject_id = subjectId, gallery_name = galleryId, selector = selector.ToUpper()});

            // Execute the request
            var requestResponse = client.Execute<EnrollResponse>(request);

            // testing
            // var content = requestResponse.Content;

            try
            {
                // Return the deserialized response
                return deserial.Deserialize<EnrollResponse>(requestResponse);
            }
            catch (SerializationException)
            {
                throw new SerializationException("Error serializing JSON string. JSON string: " +
                                                 requestResponse.Content);
            }
        }

        /// <summary>
        ///     Recognizes a previously detected/enrolled image in the system
        /// </summary>
        /// <returns>The recognition response with the possible matches</returns>
        public RecognizeResponse Recognize(string imageUrl, string galleryId)
        {
            // create client
            var client = new RestClient(API_BASE_URL);

            // create request
            var request = new RestRequest(Method.POST);

            // specify request resource
            request.Resource = "recognize";

            // specify data format
            request.RequestFormat = DataFormat.Json;

            // set request headers
            request.AddHeader("app_id", _applicationID);
            request.AddHeader("app_key", _applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // initialize json deserializer
            var deserial = new JsonDeserializer();

            // Add request content 
            request.AddBody(new {image = imageUrl, gallery_name = galleryId});

            // Execute the request
            var requestResponse = client.Execute<RecognizeResponse>(request);

            // testing
            // var content = requestResponse.Content;

            try
            {
                // Return the deserialized response
                return deserial.Deserialize<RecognizeResponse>(requestResponse);
            }
            catch (SerializationException)
            {
                throw new SerializationException("Error serializing JSON string. JSON string: " +
                                                 requestResponse.Content);
            }
        }

        /// <summary>
        ///     Returns a list of all of the user's galleries
        /// </summary>
        /// <returns>GalleryListResponse containg a list of galleries</returns>
        public GalleryListResponse ListAll()
        {
            // create client
            var client = new RestClient(API_BASE_URL);

            // create request
            var request = new RestRequest(Method.POST);

            // specify request resource
            request.Resource = "gallery/list_all";

            // specify data format
            request.RequestFormat = DataFormat.Json;

            // set request headers
            request.AddHeader("app_id", _applicationID);
            request.AddHeader("app_key", _applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // initialize json deserializer
            var deserial = new JsonDeserializer();

            // Execute the request
            var requestResponse = client.Execute<GalleryListResponse>(request);

            try
            {
                // return deserialized data
                return deserial.Deserialize<GalleryListResponse>(requestResponse);
            }
            catch (SerializationException)
            {
                throw new SerializationException("Error serializing JSON string. JSON string: " +
                                                 requestResponse.Content);
            }
        }

        /// <summary>
        ///     View the enrolled subjects in a gallery
        /// </summary>
        /// <param name="galleryId"></param>
        /// <returns>GalleryViewResponse containing a list of the subject ids</returns>
        public GalleryViewResponse View(string galleryId)
        {
            // create client
            var client = new RestClient(API_BASE_URL);

            // create request
            var request = new RestRequest(Method.POST);

            // specify request resource
            request.Resource = "gallery/view";

            // specify data format
            request.RequestFormat = DataFormat.Json;

            // set request headers
            request.AddHeader("app_id", _applicationID);
            request.AddHeader("app_key", _applicationKey);
            request.AddHeader("Content-Type", "application/json");

            // initialize json deserializer
            var deserial = new JsonDeserializer();

            // add request body
            request.AddBody(new {gallery_name = galleryId});

            // execute request
            var requestResponse = client.Execute<GalleryViewResponse>(request);

            try
            {
                // Return deserialized response
                return deserial.Deserialize<GalleryViewResponse>(requestResponse);
            }
            catch (SerializationException)
            {
                throw new SerializationException("Error serializing JSON string. JSON string: " +
                                                 requestResponse.Content);
            }
        }
    }
}