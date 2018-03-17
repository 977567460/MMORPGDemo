﻿using GameFramework;
using GameFramework.DataTable;
using System.Collections.Generic;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain
{
    public class ProcedureCreateRole : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        private ProcedureOwner m_ProcedureOwner = null;

        private PoseRoleData warriorData = null;
        private PoseRoleData masterData = null;
        private PoseRoleData shooterData = null;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_ProcedureOwner = procedureOwner;

            //初始化数据
            InitData();

            //显示第一个职业
            GameEntry.Entity.ShowPoseRole(warriorData);

            //打开创建角色界面
            RoleCreateFormParams data = new RoleCreateFormParams();
            IDataTable<DRRoleName> nameDt = GameEntry.DataTable.GetDataTable<DRRoleName>() ;
            DRRoleName[] allNames = nameDt.GetAllDataRows();
            Queue<string> namesQueue = new Queue<string>();
            for (int i = 0; i < allNames.Length; i++)
            {
                namesQueue.Enqueue(allNames[i].RoleName);
            }
            data.RandomNameQueue = namesQueue;
            data.OnClickRoleType = OnClickRoleType;
            data.OnClickCreateRole = OnClickCreateRole;
            GameEntry.UI.OpenUIForm(UIFormId.CreateRoleForm, data);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.UI.CloseUIForm(UIFormId.CreateRoleForm);
        }

        private void InitData()
        {
            warriorData = new PoseRoleData(GameEntry.Entity.GenerateTempSerialId(), 10001, ProfessionType.Warrior);
            masterData = new PoseRoleData(GameEntry.Entity.GenerateTempSerialId(), 10002, ProfessionType.Master);
            shooterData = new PoseRoleData(GameEntry.Entity.GenerateTempSerialId(), 10003, ProfessionType.Shoooter);
        }

        private void OnClickRoleType(int type)
        {
            ProfessionType pfType = (ProfessionType)type;
            switch (pfType)
            {
                case ProfessionType.Warrior:
                    GameEntry.Entity.ShowPoseRole(warriorData);

                    if (GameEntry.Entity.HasEntity(masterData.Id))
                        GameEntry.Entity.HideEntity(masterData.Id);
                    if (GameEntry.Entity.HasEntity(shooterData.Id))
                        GameEntry.Entity.HideEntity(shooterData.Id);
                    break;
                case ProfessionType.Master:
                    GameEntry.Entity.ShowPoseRole(masterData);

                    if (GameEntry.Entity.HasEntity(warriorData.Id))
                        GameEntry.Entity.HideEntity(warriorData.Id);
                    if (GameEntry.Entity.HasEntity(shooterData.Id))
                        GameEntry.Entity.HideEntity(shooterData.Id);
                    break;
                case ProfessionType.Shoooter:
                    GameEntry.Entity.ShowPoseRole(shooterData);

                    if(GameEntry.Entity.HasEntity(masterData.Id))
                        GameEntry.Entity.HideEntity(masterData.Id);
                    if (GameEntry.Entity.HasEntity(warriorData.Id))
                        GameEntry.Entity.HideEntity(warriorData.Id);
                    break;
            }
        }

        private void OnClickCreateRole(string roleName)
        {
            Log.Info("create role ,name : " + roleName);

            if (m_ProcedureOwner != null)
            {
                m_ProcedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, (int) SceneId.MainCity);
                ChangeState<ProcedureChangeScene>(m_ProcedureOwner);
            }
        }

    }

}
