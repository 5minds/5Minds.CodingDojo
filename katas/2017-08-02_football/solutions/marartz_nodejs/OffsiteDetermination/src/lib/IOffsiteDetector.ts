import { SoccerFieldInfo } from "./SoccerFieldInfo";

export interface IOffsiteDetector {
    isOffsite(soccerFieldInfo: SoccerFieldInfo): boolean;
}
