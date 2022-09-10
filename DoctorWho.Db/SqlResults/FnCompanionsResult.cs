using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.SqlResults
{
    [Keyless]
    public class FnCompanionsResult
    {
        public string CompanionsNames { get; set; }
    }
}
