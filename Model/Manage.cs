using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Manage
    {
        private const int capacity = 10;
        private static int looper = 0;
        private static IList<Dictionary<string, IssueRecEntity>> recEntity = new List<Dictionary<string, IssueRecEntity>>(capacity);
        public static void InsertRecEntity(string guid,IssueRecEntity entity)
        {
            if (recEntity.Count == 0)
            {
                Init(capacity);
            }
            Dictionary<string, IssueRecEntity> dict = new Dictionary<string, IssueRecEntity>();
            dict.Add(guid,entity);

            recEntity[looper] = dict;

            looper += 1;
            if (looper > capacity - 1)
            {
                looper = 0;
            }
        }

        public static IssueRecEntity GetRecEntity(string guid)
        {
            foreach (var dict in recEntity)
            {
                if (dict.Keys.Contains(guid))
                {
                    return dict[guid];
                }
            }

            return null;
        }

        public static void Init(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                Dictionary<string, IssueRecEntity> item = new Dictionary<string, IssueRecEntity>();
                recEntity.Add(item);
            }
        }
    }
}
