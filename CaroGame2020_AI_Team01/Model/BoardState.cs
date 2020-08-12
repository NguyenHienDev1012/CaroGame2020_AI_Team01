namespace CaroGame2020_AI_Team01.Model
{
    public class BoardState
    {
       // Mang luu lai cac trang thai cac quan co
	public int[,] boardArr;

	public int[,] BoardArr
	{
		get => boardArr;
		set => boardArr = value;
	}

	// chieu rong cua ban co
	public int rows;
	// chieu cao cua ban co
	public int columns;
	// khoi tao
	public BoardState(int rows, int columns) {
		boardArr = new int[rows,columns];
		this.rows = rows;
		this.columns = columns;
	}
	// reset ban co
	public void resetBoard(){
		boardArr = new int[rows,columns];
	}
	// Check chien thang
	public int checkEnd(int row, int col) {
		int r = 0, c = 0;
		int i;
		bool human, pc;
		// Check hang ngang
		while (c < columns - 4) {
			human = true;
			pc = true;
			for (i = 0; i < 5; i++) {
				if (boardArr[row,c + i] != 1)
					human = false;
				if (boardArr[row,c + i] != 2)
					pc = false;
			}
			if (human)
				return 1;
			if (pc)
				return 2;
			c++;
		}

		// Check  hang doc
		while (r < rows - 4) {
			human = true;
			pc = true;
			for (i = 0; i < 5; i++) {
				if (boardArr[r + i,col] != 1)
					human = false;
				if (boardArr[r + i,col] != 2)
					pc = false;
			}
			if (human)
				return 1;
			if (pc)
				return 2;
			r++;
		}

		// Check duong cheo xuong
		r = row;
		c = col;
		while (r > 0 && c > 0) {
			r--;
			c--;
		}
		while (r < rows - 4 && c < columns - 4) {
			human = true;
			pc = true;
			for (i = 0; i < 5; i++) {
				if (boardArr[r + i,c + i] != 1)
					human = false;
				if (boardArr[r + i,c + i] != 2)
					pc = false;
			}
			if (human)
				return 1;
			if (pc)
				return 2;
			r++;
			c++;
		}

		// Check duong cheo len
		r = row;
		c = col;
		while (r < rows - 1 && c > 0) {
			r++;
			c--;
		}

		while (r >= 4 && c < rows - 4) {
			human = true;
			pc = true;
			for (i = 0; i < 5; i++) {
				if (boardArr[r - i,c + i] != 1)
					human = false;
				if (boardArr[r - i,c + i] != 2)
					pc = false;
			}
			if (human)
				return 1;
			if (pc)
				return 2;
			r--;
			c++;
		}
		return 0;
	}
	// Lay trang thai cua quan co tai 1 toa do xac dinh
	public int getPosition(int x, int y) {
		return boardArr[x,y];
	}
	// set trang thai cho 1 quan co xac dinh
	public void setPosition(int x, int y, int player) {
		boardArr[x,y] = player;
	} 
    }
}