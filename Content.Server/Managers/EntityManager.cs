using Content.Server.NameSpaces;

namespace Content.Server.Managers
{
    public static class EntityManager
    {
        private static List<Entity> _entities = new List<Entity>();
        private static int _nextId = 1;

        public static Entity CreateEntity(string type, string name, float x, float y, short zindex = 0, Component[] components = null)
        {
            var entity = new Entity
            {
                Id = _nextId++,
                Type = type,
                Name = name,
                X = x,
                Y = y,
                Zindex = zindex,
                Components = components?.ToList() ?? new List<Component>()
            };
            _entities.Add(entity);
            Console.WriteLine($"Entity created: ID={entity.Id}, Type={entity.Type}, Name={entity.Name}, Position=({entity.X}, {entity.Y}, {entity.Zindex})");
            return entity;
        }

        public static void RemoveEntity(int id)
        {
            _entities.RemoveAll(e => e.Id == id);
        }

        public static Entity? GetEntity(int id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

        public static List<Entity> GetAllEntities()
        {
            return new List<Entity>(_entities);
        }
    }
}