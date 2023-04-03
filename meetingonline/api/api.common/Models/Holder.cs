using api.common.Shared;

namespace api.common.Models
{
    public class Holder : PersonInfo
    {
        public Holder(string id) : base()
        {
            Id = id;
        }

        public string IdentityUserId { get; set; }
       
        public int Shares { get; set; }
        /// <summary>
        /// The original votes
        /// </summary>
        public int OwnedVotes { get; set; }
        /// <summary>
        /// The votes received by someone who need the holder to be delegated
        /// </summary>
        public int DelegatedVotes { get; set; }
        /// <summary>
        /// The votes that share to someone as delegation, this must be less than the OwnedVotes
        /// </summary>
        public int DelegatingVotes { get; set; }
        /// <summary>
        /// Votes are used by all means such as giving to someone as delegation
        /// </summary>
        public int BlockedVotes { get; set; }
        /// <summary>
        /// Available votes whenever a action related to the owned votes, such as delegated, checkin/checkout....
        /// </summary>
        public int AvailableVotes { get; set; }

        public Occurrence CheckedInDate { get; set; }
        public Occurrence ConfirmedDate { get; set; }
        public Occurrence VotedDate { get; set; }
    }
}