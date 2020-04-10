namespace WritingPlatform.DataLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ratings
    {
        public int Id { get; set; }

        public int? Rank { get; set; }

        public int? WorkId { get; set; }

        public int? UserId { get; set; }

        public virtual Users Users { get; set; }

        public virtual Works Works { get; set; }
    }
}
