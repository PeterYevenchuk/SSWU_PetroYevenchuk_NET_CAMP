using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_11_2;

public class BlockSorter
{
    public void SortBlocks(string inputFile, int blockSize)
    {
        int blockCount = 0;
        List<int> block = new List<int>();

        using (StreamReader reader = new StreamReader(inputFile))
        {
            while (!reader.EndOfStream)
            {
                block.Add(int.Parse(reader.ReadLine()));

                if (block.Count >= blockSize)
                {
                    block.Sort();
                    WriteBlockToFile(block, blockCount);
                    block.Clear();
                    blockCount++;
                }
            }

            if (block.Count > 0)
            {
                block.Sort();
                WriteBlockToFile(block, blockCount);
            }
        }
    }

    public void WriteBlockToFile(List<int> block, int blockNumber)
    {
        string blockFile = "block_" + blockNumber.ToString("D3") + ".txt";
        File.WriteAllLines(blockFile, block.ConvertAll(x => x.ToString()));
    }
}
