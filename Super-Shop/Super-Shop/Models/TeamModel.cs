using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Shop.Models
{
    #region extension for Entity Team
    /// <summary>
    /// Since this extension method on Entity Team is very closely related to TeamModel,
    /// putting the class in the same file is a nice way to go.
    /// </summary>
    public static class TeamExtensions
    {
        /// <summary>
        /// Map a collection of Team Entities onto a collection of TeamModels 
        /// </summary>
        /// <param name="source">IQueryable<Team> as source resultset to map to IQueryable<TeamModel></param>
        /// <returns>IQueryable<TeamModel></returns>
        public static IQueryable<TeamModel> ToModel(this IQueryable<Team> source)
        {
            return source.Select(t => new TeamModel
            {
                Id = t.Id,
                Name = t.Name,
                PowerLevel = t.PowerLevel,
                ImageUri = t.ImageUri,
                HeroNames = t.Heroes.Select(h => h.Name).ToList()
            });
        }
    }
    #endregion

    #region TeamModel class
    public class TeamModel
    {
        private int _powerLevel;

        public TeamModel()
        {

        }
        public TeamModel(Team teamEntity)
        {
            Id = teamEntity.Id;
            Name = teamEntity.Name;
            PowerLevel = teamEntity.PowerLevel;
            ImageUri = teamEntity.ImageUri;
            // HeroNames =.....

        }
        public int Id { get; set; }

        public string Name { get; set; }
        public int PowerLevel
        {
            get
            {
                //TODO: How to calculate team power?
                return _powerLevel;
            }
            set
            {
                _powerLevel = value;
            }
        }

        public string ImageUri { get; set; }

        public List<string> HeroNames { get; set; }
    }
    #endregion
}
