using System;
using System.Collections;
using System.Collections.Generic;

namespace AbstractDataTypeLibrary
{
    public class BTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count;

        public BinaryTreeNode<T> Head
        {
            get { return _head; }
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(T value)
        {
            AddExecutor(ref _head, value);
            _count++;
        }

        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;
            current = FindWithParent(value, out parent);

            //node not found, nothing to remove
            if (current == null)
            {
                return false;
            }

            _count--;

            if (current.Right == null)
            {
                ReplaceStructureInRemove(parent, current, current.Left);
                return true;
            }
            // If current's right child has no left child,
            // then current's right child replaces current
            if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                ReplaceStructureInRemove(parent, current, current.Right);

                return true;
            }

            // If current's right child has a left child,
            // replace current with current's right child's left-most child
            BinaryTreeNode<T> currentRightLeftmostChild = current.Right.Left;
            BinaryTreeNode<T> currentRightLeftmostChildParent = current.Right;

            //go as deeper as possible to the left
            while (currentRightLeftmostChild.Left != null)
            {
                currentRightLeftmostChildParent = currentRightLeftmostChild;
                currentRightLeftmostChild = currentRightLeftmostChild.Left;
            }

            // the parent's left subtree becomes the leftmost's right subtree
            currentRightLeftmostChildParent.Left = currentRightLeftmostChild.Right;

            // assign leftmost's left and right to current's left and right children
            currentRightLeftmostChild.Left = current.Left;
            currentRightLeftmostChild.Right = current.Right;

            ReplaceStructureInRemove(parent, current, currentRightLeftmostChild);
            return true;
        }

        private void ReplaceStructureInRemove(
            BinaryTreeNode<T> parent,
            BinaryTreeNode<T> current,
            BinaryTreeNode<T> targetChild)
        {
            if (parent == null)
            {
                _head = targetChild;
                return;
            }

            int result = parent.CompareTo(current.Value);
            if (result > 0)
            {
                // if parent value is greater than current value
                // make the current right child a left child of parent
                parent.Left = targetChild;
                return;
            }

            // if parent value is less than current value
            // make the target child a right child of parent
            parent.Right = targetChild;
            return;
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }

        //LUIS review this algorithm...
        public IEnumerator<T> InOrderTraversal()
        {
            // Non-recursive algorithm
            if (_head == null)
                yield break;

            // store the nodes we've skipped in this stack (non-recursive approach)
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();

            BinaryTreeNode<T> current = _head;

            // we need to keep track of whether or not we should be going
            // to the left node or the right node next.
            bool goLeftNext = true;

            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    // push everything but the left-most node to the stack
                    // we'll yield the left-most after this block
                    while (current.Left != null)
                    {
                        //LUIS: Is this correct??
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Value;

                //LUIS: return the left, then the parent!!
                //yield return stack.Pop();

                if (current.Right != null)
                {
                    current = current.Right;

                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddExecutor(ref BinaryTreeNode<T> node, T value)
        {
            // if there is no left child make this the new left
            if (node == null)
            {
                node = new BinaryTreeNode<T>(value);
            }
            else
            {
                // else add it to the left node
                AddBalancing(node, value);
            }
        }

        private void AddBalancing(BinaryTreeNode<T> node, T value)
        {
            // Case 1: Value is less than the current node value
            if (value.CompareTo(node.Value) < 0)
            {
                BinaryTreeNode<T> left = node.Left;
                AddExecutor(ref left, value);
                node.Left = left;
            }
            // Case 2: Value is equal to or greater than the current value
            else
            {
                BinaryTreeNode<T> right = node.Right;
                AddExecutor(ref right, value);
                node.Right = right;
            }
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _head;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    // go left
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // go right
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // match found
                    break;
                }
            }

            return current;
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            action(node.Value);
            PreOrderTraversal(action, node.Left);
            PreOrderTraversal(action, node.Right);
        }

        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            PostOrderTraversal(action, node.Left);
            PostOrderTraversal(action, node.Right);
            action(node.Value);
        }

        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(action, node.Left);
            action(node.Value);
            InOrderTraversal(action, node.Right);
        }
    }

    public class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        public BinaryTreeNode<TNode> Left { get; set; }

        public BinaryTreeNode<TNode> Right { get; set; }

        public TNode Value { get; private set; }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}
