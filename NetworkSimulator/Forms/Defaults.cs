namespace NetworkSimulator
{
	public static class Defaults
	{
		//	num columns
		public static int HNodes = 6;
		//	num rows
		public static int VNodes = 5;
		//	elements processed per interval
		public static int Base = 4;
		//	elements in the queue
		public static int Buffer = 10;
		//	max num of created elements on a vertex per interval
		public static int GenLimit = 3;
		//	load ration on which a vertex is considered FULL
		public static float MaxLoadRatio = 0.97f;
		//	should the program use djekstra's algorith
		public static bool Djekstra = false;
		//	pause in milliseconds between each iteration
		public static int Delay = 2000;
		//	default map height
		public static int MapHeight = 600;
		//	default map width
		public static int MapWidth = 800;
		//	session's limit
		public static int sessionCount = 200;
		//	messages gen per interval for the whole session
		public static int sessionGenLimit = 10;
	}
}

