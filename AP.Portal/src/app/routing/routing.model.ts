export interface Group {
  groupId: string;
  institutionIds: string[];
  endpoints: Endpoint[],
}

export interface Endpoint {
  name: string;
  type: string;
  url: string;
  authorizationList?: string;
  businessMessageRule?: BusinessMessageRule;
}

export interface Predicate {
  type: string;
  key: string;
  value: string;
}

export interface Aggregate {
  type: string;
  children: BusinessMessageRule[]
}

export type BusinessMessageRule = Predicate | Aggregate;
