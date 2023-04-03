
export enum CriterionType {
    Not,
    And,
    AndAlso
}

export enum Operator {
    Equals,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual,
    DifferenceOf,
    Contains
}

export class Criterion {
    constructor(field: string, name: string, type: CriterionType = CriterionType.Not) {
        this.operator = Operator.Equals;
        this.value = "";
        this.field = field;
        this.type = type;
        this.name = name; 
    }

    name: string;
    type: CriterionType;
    operator: Operator;
    value: string;
    field: string; 
}

export class Filter {
    constructor(criteria: Criterion[], sorted: ColumnSortedEvent) {
        this.criteria = criteria;
        this.pageIndex = 1;
        this.pageSize = 30;
        this.sortField = sorted;
    }

    criteria: Criterion[];
    pageIndex: number;
    pageSize: number;
    sortField: ColumnSortedEvent;

    get(field: string) {
        return this.criteria.filter(x => x.field === field)[0];
    }
}

export class ColumnSortedEvent {
    constructor(sortColumn: string, sortDirection: string) {
        this.fieldName = sortColumn;
        this.sortDirection = sortDirection; 
        this.isAscending = !(sortDirection === 'asc');
    }
    fieldName: string;
    sortDirection: string;
    isAscending: boolean;
}