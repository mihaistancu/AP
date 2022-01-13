export interface Group {
  groupId: string;
  institutionIds: string[];
  endpoints: (PushEndpoint | PullEndpoint) [],
}

export interface PushEndpoint {
  type: 'push';
  name: string;
  naUrl: string;
  outboxUrl: string;
  businessMessageRule?: BusinessMessageRule;
  systemMessageSubscriptions?: string[];
}

export interface PullEndpoint {
  type: 'pull';
  name: string;
  inboxUrl: string;
  outboxUrl: string;
  authorizationList?: string;
  businessMessageRule?: BusinessMessageRule;
  systemMessageSubscriptions?: string[];
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
