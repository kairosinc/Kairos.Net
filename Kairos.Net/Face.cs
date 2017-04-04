namespace Kairos.Net
{
    /// <summary>
    ///     Information about a detected face on an image
    /// </summary>
    public class Face
    {
        public int topLeftX { get; set; }
        public int topLeftY { get; set; }
        public int chinTipX { get; set; }
        public int chinTipY { get; set; }
        public int rightEyeCenterX { get; set; }
        public int rightEyeCenterY { get; set; }
        public int leftEyeCenterX { get; set; }
        public int leftEyeCenterY { get; set; }
        public int pitch { get; set; }
        public int yaw { get; set; }
        public int roll { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int face_id { get; set; }
        public float quality { get; set; }
        public FaceAttributes attributes { get; set; }
    }
}