public class Solution
{
    IList<IList<int>> result;
    int m, n;
    int[][] dirs;
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        if (heights == null || heights.Length == 0)
        {
            return result;
        }

        result = new List<IList<int>>();
        m = heights.Length;
        n = heights[0].Length;
        dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];
        int[][] pReachable = new int[m][];
        int[][] aReachable = new int[m][];
        for (int i = 0; i < m; i++)
        {
            pReachable[i] = new int[n];
            aReachable[i] = new int[n];
        }
        for (int i = 0; i < m; i++)
        {
            DFS(heights, i, 0, pReachable);
            DFS(heights, i, n - 1, aReachable);
        }
        for (int i = 0; i < n; i++)
        {
            DFS(heights, 0, i, pReachable);
            DFS(heights, m - 1, i, aReachable);
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (pReachable[i][j] == 1 && aReachable[i][j] == 1)
                {
                    result.Add(new List<int>() { i, j });
                }
            }
        }
        return result;
    }

    public void DFS(int[][] heights, int row, int column, int[][] reachable)
    {
        reachable[row][column] = 1;
        foreach (var dir in dirs)
        {
            var nr = row + dir[0];
            var nc = column + dir[1];
            if (nr < 0 || nr == m || nc < 0 || nc == n || reachable[nr][nc] == 1)
            {
                continue;
            }
            if (heights[row][column] <= heights[nr][nc])
            {
                DFS(heights, nr, nc, reachable);
            }
        }
    }
}