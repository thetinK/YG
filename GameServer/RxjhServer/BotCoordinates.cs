using System.Collections.Generic;

namespace RxjhServer
{
    public class BotCoordinates
    {
        public int Index { get; set; }      // ลำดับที่ของบอท
        public int MonsterId { get; set; }  // รหัสประจำตัวมอนสเตอร์
        public int Level { get; set; }      // ระดับของมอนสเตอร์
        public float X { get; set; }        // ตำแหน่ง X บนแผนที่
        public float Y { get; set; }        // ตำแหน่ง Y บนแผนที่


        // Dictionary สำหรับเก็บข้อมูลบอทมอนสเตอร์ทั้งหมด
        // Key: index (int), Value: BotCoordinates object
        public Dictionary<int, BotCoordinates> BotMonsters { get; set; }
    }
}