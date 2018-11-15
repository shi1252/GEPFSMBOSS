# GEPFSMBOSS
Game Engine Programming FSM Boss

# GameLib 추가 사항
AttackCheck : 공격 공용 함수. 공격시 공격자 및 타겟 서로 바라보도록 회전 <br>
RotateFromTo : 회전 공용 함수

# Goblin State
IDLE <br>
PATROL <br>
CHASE<br>
ATTACK<br>
DEAD<br>

# Goblin Pattern (Phase)
Phase1 : 소환수 2마리 소환<br>
Phase2 : 공격력 및 데미지 감소율 1.5배<br>

# StatData
maxHp : 최대 체력<br>
baseRange : 공격 범위<br>
attackPoint : 공격력<br>
moveSpeed : 이동 속도<br>
defenseP : 데미지 감소율<br>

# GoblinStatData
Phase1HpPercent : 1페이즈 체력 퍼센트<br>
Phase2HpPercent : 2페이즈 체력 퍼센트<br>
matpi : 소환수 게임 오브젝트<br>
