using System.Collections.Generic;

namespace RxjhServer
{
    public class PkNotification
    {
        public int MinKillCount { get; set; }    // จำนวนการฆ่าผู้เล่นขั้นต่ำเพื่อได้โบนัส
        public int MaxKillCount { get; set; }    // จำนวนการฆ่าผู้เล่นสูงสุดสำหรับโบนัสนี้
        public int AttackBonus { get; set; }     // โบนัสค่าการโจมตีที่จะได้รับ
        public int DefenseBonus { get; set; }    // โบนัสค่าการป้องกันที่จะได้รับ
        public int HealthBonus { get; set; }     // โบนัสพลังชีวิตที่จะได้รับ
        public string LoginMessage { get; set; } // ข้อความแจ้งเตือนที่แสดงเมื่อเข้าเกม


// Dictionary สำหรับเก็บข้อมูลการแจ้งเตือน PK ทั้งหมด
// Key: index (int), Value: PkNotification object
public Dictionary<int, PkNotification> PkNotificationData { get; set; }
    }
}