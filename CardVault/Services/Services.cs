using CardVault.Models;
using CardVault.ModelsDTO;
using CardVault.Models;
using CardVault.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlazorServerAuthenticationAndAuthorization.Services
{
    public class Services
    {
        private readonly MyDBContext dbContext;

        public Services()
        {
            dbContext = new MyDBContext();
        }

        public IList<CardModelClass> GetAllCards()
        {
            return dbContext.Cards
                .Include(c => c.CardColors)
                .ThenInclude(cc => cc.Color)
                .Include(c => c.CardTypes)
                .ThenInclude(ct => ct.Type)
                .Select(p => new CardModelClass
                {
                    Id = p.Id,
                    Name = p.Name,
                    ManaCost = p.ManaCost,
                    ConvertedManaCost = p.ConvertedManaCost,
                    Type = string.Join(", ", p.CardTypes.Select(ct => ct.Type.Name)),
                    RarityCode = p.RarityCode,
                    SetCode = p.SetCode,
                    Text = p.Text,
                    Flavor = p.Flavor,
                    Power = p.Power,
                    Toughness = p.Toughness,
                    Layout = p.Layout,
                    MultiverseId = p.MultiverseId,
                    OriginalImageUrl = p.OriginalImageUrl ?? "images/placeholder.png",
                    Image = p.Image,
                    Colors = p.CardColors.Select(cc => cc.Color.Name).ToList(),
                    Types = p.CardTypes.Select(ct => ct.Type.Name).ToList()
                })
                .OrderBy(o => o.Name)
                .Take(150)
                .ToList();
        }

        public CardModelClass GetCardById(long id)
        {
            return dbContext.Cards
                .Include(c => c.CardColors)
                .ThenInclude(cc => cc.Color)
                .Include(c => c.CardTypes)
                .ThenInclude(ct => ct.Type)
                .Where(p => p.Id == id)
                .Select(p => new CardModelClass
                {
                    Id = p.Id,
                    Name = p.Name,
                    ManaCost = p.ManaCost,
                    ConvertedManaCost = p.ConvertedManaCost,
                    Type = string.Join(", ", p.CardTypes.Select(ct => ct.Type.Name)),
                    RarityCode = p.RarityCode,
                    SetCode = p.SetCode,
                    Text = p.Text,
                    Flavor = p.Flavor,
                    Power = p.Power,
                    Toughness = p.Toughness,
                    Layout = p.Layout,
                    MultiverseId = p.MultiverseId,
                    OriginalImageUrl = p.OriginalImageUrl ?? "images/placeholder.png",
                    Image = p.Image,
                    Colors = p.CardColors.Select(cc => cc.Color.Name).ToList(),
                    Types = p.CardTypes.Select(ct => ct.Type.Name).ToList()
                })
                .FirstOrDefault();
        }

        public IList<CardModelClass> GetFilteredCards(string color, string rarityCode, string manaCost, string type)
        {
            var query = dbContext.Cards
                .Include(c => c.CardColors)
                .ThenInclude(cc => cc.Color)
                .Include(c => c.CardTypes)
                .ThenInclude(ct => ct.Type)
                .AsQueryable();

            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(w => w.CardColors.Any(cc => cc.Color.Name == color));
            }

            if (!string.IsNullOrEmpty(rarityCode))
            {
                query = query.Where(w => w.RarityCode == rarityCode);
            }

            if (!string.IsNullOrEmpty(manaCost))
            {
                query = query.Where(w => w.ManaCost == manaCost);
            }

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(w => w.CardTypes.Any(ct => ct.Type.Name == type));
            }

            return query.Select(p => new CardModelClass
            {
                Id = p.Id,
                Name = p.Name,
                ManaCost = p.ManaCost,
                ConvertedManaCost = p.ConvertedManaCost,
                Type = string.Join(", ", p.CardTypes.Select(ct => ct.Type.Name)),
                RarityCode = p.RarityCode,
                SetCode = p.SetCode,
                Text = p.Text,
                Flavor = p.Flavor,
                Power = p.Power,
                Toughness = p.Toughness,
                Layout = p.Layout,
                MultiverseId = p.MultiverseId,
                OriginalImageUrl = p.OriginalImageUrl ?? "images/placeholder.png",
                Image = p.Image,
                Colors = p.CardColors.Select(cc => cc.Color.Name).ToList(),
                Types = p.CardTypes.Select(ct => ct.Type.Name).ToList()
            })
            .OrderBy(o => o.Name)
            .ToList();
        }
    }
}
