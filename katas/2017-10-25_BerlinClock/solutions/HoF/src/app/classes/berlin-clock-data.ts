export class BerlinClockData {
    readonly isFiveHourLightOneOn: boolean;
    readonly isFiveHourLightTwoOn: boolean;
    readonly isFiveHourLightThreeOn: boolean;
    readonly isFiveHourLightFourOn: boolean;
    readonly isHourLightOneOn: boolean;
    readonly isHourLightTwoOn: boolean;
    readonly isHourLightThreeOn: boolean;
    readonly isHourLightFourOn: boolean;
    readonly isFiveMinuteLightOneOn: boolean;
    readonly isFiveMinuteLightTwoOn: boolean;
    readonly isFiveMinuteLightThreeOn: boolean;
    readonly isFiveMinuteLightFourOn: boolean;
    readonly isFiveMinuteLightFiveOn: boolean;
    readonly isFiveMinuteLightSixOn: boolean;
    readonly isFiveMinuteLightSevenOn: boolean;
    readonly isFiveMinuteLightHeightOn: boolean;
    readonly isFiveMinuteLightNineOn: boolean;
    readonly isFiveMinuteLightTenOn: boolean;
    readonly isFiveMinuteLightElevenOn: boolean;
    readonly isMinuteLightOneOn: boolean;
    readonly isMinuteLightTwoOn: boolean;
    readonly isMinuteLightThreeOn: boolean;
    readonly isMinuteLightFourOn: boolean;
    readonly isSecondLightOn: boolean;

    constructor (time: Date)
    {
        const hours = time.getHours();
        const hoursModFive = hours % 5;
        const minutes = time.getMinutes();
        const minutesModFive = minutes % 5;
        const seconds = time.getSeconds();
    
        this.isFiveHourLightOneOn = hours > 4;
        this.isFiveHourLightTwoOn = hours > 9;
        this.isFiveHourLightThreeOn = hours > 14;
        this.isFiveHourLightFourOn = hours > 19;
        this.isHourLightOneOn = hoursModFive > 0;
        this.isHourLightTwoOn = hoursModFive > 1;
        this.isHourLightThreeOn = hoursModFive > 2;
        this.isHourLightFourOn = hoursModFive > 3;
        this.isFiveMinuteLightOneOn = minutes > 4;
        this.isFiveMinuteLightTwoOn = minutes > 9;
        this.isFiveMinuteLightThreeOn = minutes > 14;
        this.isFiveMinuteLightFourOn = minutes > 19;
        this.isFiveMinuteLightFiveOn = minutes > 24;
        this.isFiveMinuteLightSixOn = minutes > 29;
        this.isFiveMinuteLightSevenOn = minutes > 34;
        this.isFiveMinuteLightHeightOn = minutes > 39;
        this.isFiveMinuteLightNineOn = minutes > 44;
        this.isFiveMinuteLightTenOn = minutes > 49;
        this.isFiveMinuteLightElevenOn = minutes > 54;
        this.isMinuteLightOneOn = minutesModFive > 0;
        this.isMinuteLightTwoOn = minutesModFive > 1;
        this.isMinuteLightThreeOn = minutesModFive > 2;
        this.isMinuteLightFourOn = minutesModFive > 3;
        this.isSecondLightOn = seconds % 2 < 1;
    }
}
