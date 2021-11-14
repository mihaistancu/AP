export interface Group {
  groupId: string;
  institutionIds: string[];
  rules: Rule[],
}

export interface Rule {
  name: string;
  type: string;
  url: string;
  condition?: Condition;
}

export interface Predicate {
  type: string;
  key: string;
  value: string;
}

export interface Aggregate {
  type: string;
  children: Condition[]
}

export type Condition = Predicate | Aggregate;
