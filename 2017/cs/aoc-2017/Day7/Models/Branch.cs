namespace Day7.Models
{
    public class Branch
    {
        public Prog Parent { get; set; }
        public int BranchWeight { get; set; }
    }
}