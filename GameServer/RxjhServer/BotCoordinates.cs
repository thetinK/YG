using System.Collections.Generic;

namespace RxjhServer
{
    public class BotCoordinates
    {
        public int Index { get; set; }      // �ӴѺ���ͧ�ͷ
        public int MonsterId { get; set; }  // ���ʻ�Шӵ���͹�����
        public int Level { get; set; }      // �дѺ�ͧ�͹�����
        public float X { get; set; }        // ���˹� X ��Ἱ���
        public float Y { get; set; }        // ���˹� Y ��Ἱ���


        // Dictionary ����Ѻ�红����źͷ�͹����������
        // Key: index (int), Value: BotCoordinates object
        public Dictionary<int, BotCoordinates> BotMonsters { get; set; }
    }
}