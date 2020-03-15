namespace Inheritance.MapObjects
{
    public interface ICollectible
    {
        Treasure Treasure { get; set; }
    }

    public interface IHaveArmy
    {
        Army Army { get; set; }
    }

    public interface IHaveOwner
    {
        int Owner { get; set; }
    }

    public class Dwelling : IHaveOwner
    {
        public int Owner { get; set; }
    }

    public class Mine : IHaveOwner, IHaveArmy, ICollectible
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    public class Creeps : IHaveArmy, ICollectible
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
    }

    public class Wolfs : IHaveArmy
    {
        public Army Army { get; set; }
    }

    public class ResourcePile : ICollectible
    {
        public Treasure Treasure { get; set; }
    }

    public static class Interaction
    {
        public static void Make(Player player, object mapObject)
        {
            if (mapObject is IHaveArmy && !player.CanBeat(((IHaveArmy)mapObject).Army))
            {
                player.Die();
                return;
            }

            if (mapObject is IHaveOwner)
                ((IHaveOwner)mapObject).Owner = player.Id;

            if (mapObject is ICollectible)
                player.Consume(((ICollectible)mapObject).Treasure);
        }
    }
}
