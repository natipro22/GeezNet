using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeezNet.Services;

public class GeezCalculator
{
    private const int ONE = 1;
    private const int HUNDRED = 100;
    private const int TEN_THOUSAND = 10000;
    private readonly Queue<(int block, int separator)> queue;
    private int total;
    private int subTotal;

    public GeezCalculator(Queue<(int block, int separator)> queue)
    {
        this.queue = queue;
        total = 0;
        subTotal = 0;
    }

    public void Calculate()
    {
        ResetSubTotalToZero();

        foreach ((int block, int separator) token in queue)
        {
            ProcessToken(token);
        }
    }

    private void ResetSubTotalToZero()
    {
        subTotal = 0;
    }

    private void ProcessToken((int block, int separator) token)
    {
        int block = token.block;
        int separator = token.separator;

        ProcessBySeparator(block, separator);
    }

    private void ProcessBySeparator(int block, int separator)
    {
        switch (separator)
        {
            case ONE:
                AddToTotal(block);
                break;
            case HUNDRED:
                UpdateSubTotal(block);
                break;
            case TEN_THOUSAND:
            default:
                UpdateTotal(block);
                break;
        }
    }

    private void AddToTotal(int block)
    {
        total += subTotal + block;
        ResetSubTotalToZero();
    }

    private bool IsLeading(int block)
    {
        return IsBlockZero(block) && IsSubtotalZero();
    }

    private bool IsBlockZero(int block)
    {
        return block == 0;
    }

    private bool IsSubtotalZero()
    {
        return subTotal == 0;
    }

    private void AddToSubTotal(int number)
    {
        subTotal += number;
    }

    private bool IsLeadingTenThousand(int block)
    {
        return IsTotalZero() && IsLeading(block);
    }

    private bool IsTotalZero()
    {
        return total == 0;
    }

    private void MultiplyTotalBy10k()
    {
        total *= TEN_THOUSAND;
    }

    public int GetCalculated()
    {
        return total;
    }

    private void UpdateSubTotal(int block)
    {
        if (IsLeading(block))
        {
            block = ONE;
        }

        block *= HUNDRED;
        AddToSubTotal(block);
    }

    private void UpdateTotal(int block)
    {
        if (IsLeadingTenThousand(block))
        {
            block = ONE;
        }

        AddToTotal(block);
        MultiplyTotalBy10k();
    }
}

