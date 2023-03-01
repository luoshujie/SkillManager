using System;
using UnityEngine;

public class BehaviorTreeManager:MonoBehaviour
{
    public static BehaviorTreeManager instance;
    public BehaviorTreeTaskRoot tree;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
    }

    public void RunTree(BehaviorTreeTaskRoot enter)
    {
        tree = enter;
    }
    //--重置树下所有Action
    public void ResetTreeActions()
    {
        BehaviorTreeTaskRoot treeRoot = GetCurTreeRoot();
        treeRoot.ResetAllActionsState();
    }

    public BehaviorTreeTaskRoot GetCurTreeRoot()
    {
        return tree;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BehaviorTreeTaskRoot treeRoot = BehaviorTreeManager.instance.GetCurTreeRoot();
            object b = treeRoot.GetGlobalParam("OnPause");
            bool isB = (bool) b;
            treeRoot.SetGlobalParam("OnPause",!isB);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            BehaviorTreeTaskRoot root = BuildTree();
            BehaviorTreeManager.instance.RunTree(root);
        }

       UpdateTask();
    }

    public void UpdateTask()
    {
        if (tree != null)
        {
            TaskStatus status = tree.OnUpdate();
        }
    }

    /// <summary>
    /// 代码拼接行为树有代码结构顺序要求，
    /// 代码顺序也遵从行为树的图示，上到下，从左到右拼接
    /// 上层或者本节点的前一个节点完成才能进行下一个
    /// </summary>
    public BehaviorTreeTaskRoot BuildTree()
    {
        BehaviorTreeTaskRoot taskRoot = new BehaviorTreeTaskRoot();
        taskRoot.SetGlobalParam("OnPause",true);
        //这里直接使用Repeater作为入口并且检测，相当于Entry
        BehaviorTreeRepeater entry = new BehaviorTreeRepeater();
        entry.name = "第0个复合节点repeat == Entry";
        entry.SetRepeatCount(-1);
        //根节点添加layer：1
        taskRoot.PushTask(entry);
        //layer:2
        BehaviorTreeSelector selector1 = new BehaviorTreeSelector();
        selector1.name = "第1个复合节点selector";
        entry.AddChild(selector1);
        //layer3
        BehaviorTreeSequence sequence2 = new BehaviorTreeSequence();
        sequence2.name = "第2个复合节点sequence";
        selector1.AddChild(sequence2);
        //layer4 并行
        BehaviorTreeLogCondition logCondition = new BehaviorTreeLogCondition();
        logCondition.name = "并行第3个叶子节点 LogCondition";
        BehaviorTreeWait wait = new BehaviorTreeWait();
        wait.name = "并行第4个叶子节点 wait";
        wait.SetWait(2);
        BehaviorTreeLog log = new BehaviorTreeLog();
        log.name = "并行第5个叶子节点 log";
        sequence2.AddChild(logCondition);
        sequence2.AddChild(wait);
        sequence2.AddChild(log);
        BehaviorTreePauseTree pauseTree = new BehaviorTreePauseTree();
        pauseTree.name = "并行第6个叶子节点 pauseTree ";
        sequence2.AddChild(pauseTree);
        return taskRoot;
    }
}