export class EnumExtension {
    private constructor() {
    }

    public static getNamesAndValues<T extends string>(e: any) {
        return EnumExtension.getNames(e).map(n => ({ name: e[n], value: n as T }));
    }

    public static getNames(e: any) {
        return Object.keys(e).filter(k => typeof e[k] === "string") as string[];
    }

    public static getValues<T extends string>(e: any) {
        return Object.keys(e)
            .map(k => e[k])
            .filter(v => typeof v === "string") as T[];
    }
}