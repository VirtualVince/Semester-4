using System;
using System.Collections.Generic;

namespace Patterns
{
    interface IIterator
    {
        string FirstItem { get; }
        string NextItem { get; }
        string CurrentItem { get; }
        bool IsDone { get; }
    }

    interface IAggregate
    {
        IIterator GetIterator();
        string this[int itemIndex] { set; get; }
        int Count { get; }
    }

    class MyAggregate : IAggregate
    {
        private List<string> values_ = new List<string>();

        public IIterator GetIterator()
        {
            return new MyIterator(this);
        }

        public string this[int itemIndex]
        {
            get => itemIndex < values_.Count ? values_[itemIndex] : string.Empty;
            set => values_.Add(value);
        }

        public int Count => values_.Count;
    }

    class MyIterator : IIterator
    {
        private IAggregate aggregate_;
        private int currentIndex_ = 0;

        public MyIterator(IAggregate aggregate)
        {
            aggregate_ = aggregate;
        }

        public string FirstItem
        {
            get
            {
                currentIndex_ = 0;
                return aggregate_[currentIndex_];
            }
        }

        public string NextItem
        {
            get
            {
                currentIndex_++;
                return IsDone ? string.Empty : aggregate_[currentIndex_];
            }
        }

        public string CurrentItem => aggregate_[currentIndex_];

        public bool IsDone => currentIndex_ >= aggregate_.Count;
    }
}
