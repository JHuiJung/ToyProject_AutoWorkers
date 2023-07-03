using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Worker_States
{

    public class GoWork : Worker_StateBase
    {
        //일하는 곳으로가는 상태
        float time = 0f;
        float n_time = 0f;
        GameObject target = null;
        public override void Enter(WorkerController wc)
        {
            Debug.Log("일하러 가볼까?");
            if (target == null)
            {
                target = Rs_Manager.Inst.GetNearObj(wc.GetPosition());
                if (target != null)
                {
                    wc.MoveAgent(target.GetComponent<Transform>().position);
                    target.GetComponent<Rs_Base>().getKey();
                }

            }


        }

        public override void Excute(WorkerController wc)
        {

            time += Time.deltaTime;
            if (time >= 1f)
            {
                time = 0f;
                n_time += 1f;
                if (wc.attachedObj != null)
                {

                    if (wc.bag.IsFull)
                    {

                        wc.Change_State(new BackHome());
                    }
                    else
                    {
                        if (wc.attachedObj.tag == "Rs")
                        {
                            if (wc.attachedObj.GetComponent<Rs_Base>().isEmpty)
                            {
                                wc.Change_State(new BackHome());
                            }
                            else
                            {
                                wc.attachedObj.GetComponent<Rs_Base>().resource_Cnt -= 1;
                                wc.bag.AddRs(1);
                                wc.stress += Random.Range(1, 10);
                                if (wc.stress >= 80) { wc.Change_State(new GoRest()); }
                            }

                        }

                    }


                }

            }
            if (target == null)
            {
                target = Rs_Manager.Inst.GetNearObj(wc.GetPosition());
                if (target != null)
                {
                    wc.MoveAgent(target.GetComponent<Transform>().position);
                    target.GetComponent<Rs_Base>().getKey();
                }

            }

        }

        public override void Exit(WorkerController wc)
        {
            target.GetComponent<Rs_Base>().return_Key();


        } 
    }

        public class BackHome : Worker_StateBase
        {
            float time = 0f;
            float n_time = 0f;
            public override void Enter(WorkerController wc)
            {
                wc.MoveAgent(GameObject.FindGameObjectWithTag("Nexus").GetComponent<Transform>().position);
            }

            public override void Excute(WorkerController wc)
            {
                time += Time.deltaTime;
                if (time >= 1f)
                {
                    time = 0f;
                    n_time += 1f;
                    if (wc.attachedObj != null)
                    {
                        if (wc.bag.IsEmpty)
                        {
                            wc.Change_State(new GoWork());
                        }
                        else
                        {
                            if (wc.attachedObj.tag == "Nexus")
                            {

                                wc.attachedObj.GetComponent<Worker_Bag>().AddRs(wc.bag.DropRs(1));
                            }

                        }
                    }

                }
            }

            public override void Exit(WorkerController wc)
            {
                Debug.Log("일하러 가자");
            }
        }

        public class GoRest : Worker_StateBase
        {
            float time = 0f;
            float n_time = 0f;
            public override void Enter(WorkerController wc)
            {
                GameObject re = GameObject.FindGameObjectWithTag("Rest");
                wc.MoveAgent(re.GetComponent<Transform>().position);
            }

            public override void Excute(WorkerController wc)
            {
                time += Time.deltaTime;
                if (time >= 1f)
                {
                    time = 0f;
                    n_time += 1f;
                    if (wc.attachedObj != null && wc.attachedObj.tag == "Rest")
                    {
                        wc.stress -= Random.Range(1, 10);
                        if (wc.stress <= 20)
                        {
                            wc.Change_State(new GoWork());
                        }
                    }

                }
            }

            public override void Exit(WorkerController wc)
            {
                Debug.Log("잘 쉬었당");
            }
        }
    }


