public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var validateVertical = new int[9, 9];
        var validateHorizontal = new int[9, 9];
        var validateSubbox = new int[9, 9];


        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (int.TryParse($"{board[i][j]}", out var value))
                {
                    value--;
                    var subboxI = (i / 3);
                    subboxI *= 3;
                    var subbox = subboxI + (j / 3);
                    if (validateVertical[i, value] == 1
                        || validateHorizontal[j, value] == 1
                        || validateSubbox[subbox, value] == 1)
                    {
                        return false;
                    }

                    validateVertical[i, value]++;
                    validateHorizontal[j, value]++;
                    validateSubbox[subbox, value]++;
                }
            }
        }

        return true;
    }
}
