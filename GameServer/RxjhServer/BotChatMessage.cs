using System.Collections.Generic;

namespace RxjhServer
{
    // คลาสสำหรับเก็บข้อมูลข้อความแชทของบอท
    public class BotChatMessage
    {
        public int PlayerId { get; set; }    // รหัสผู้เล่นบอท
        public int BotMode { get; set; }     // โหมดการทำงานของบอท (เช่น 1=แชททั่วไป, 2=ประกาศ)
        public string ChatContent { get; set; } // เนื้อหาข้อความที่บอทจะพูด


        // Dictionary สำหรับเก็บข้อความแชทของบอททั้งหมด
        // Key: index (int), Value: BotChatMessage object
        public Dictionary<int, BotChatMessage> BotChatMessages { get; set; }
    }
}