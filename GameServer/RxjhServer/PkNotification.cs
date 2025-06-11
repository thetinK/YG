using System.Collections.Generic;

namespace RxjhServer
{
    public class PkNotification
    {
        public int MinKillCount { get; set; }    // �ӹǹ��æ�Ҽ����蹢�鹵��������⺹��
        public int MaxKillCount { get; set; }    // �ӹǹ��æ�Ҽ������٧�ش����Ѻ⺹�ʹ��
        public int AttackBonus { get; set; }     // ⺹�ʤ�ҡ�����շ������Ѻ
        public int DefenseBonus { get; set; }    // ⺹�ʤ�ҡ�û�ͧ�ѹ�������Ѻ
        public int HealthBonus { get; set; }     // ⺹�ʾ�ѧ���Ե�������Ѻ
        public string LoginMessage { get; set; } // ��ͤ�������͹����ʴ�����������


// Dictionary ����Ѻ�红����š������͹ PK ������
// Key: index (int), Value: PkNotification object
public Dictionary<int, PkNotification> PkNotificationData { get; set; }
    }
}