import { AttackDirection } from "./AttackDirection";
import { SoccerFieldInfo } from "./SoccerFieldInfo";
import { SoccerFieldData } from "./SoccerFieldData";

export interface ISoccerFieldDataAnalyzer {
    analyze(soccerFieldData: SoccerFieldData, attackDirection: AttackDirection): SoccerFieldInfo;
}