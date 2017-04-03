namespace Kairos.API
{
    /// <summary>
    ///     Image information after a user has been enrolled
    /// </summary>
    public class EnrollImage : ImageBase
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public EnrollImage()
        {
            Transaction = new Transaction();
        }

        public Transaction Transaction { get; set; }
    }
}