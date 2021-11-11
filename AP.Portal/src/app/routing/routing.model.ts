export interface Group {
  groupId: string;
  institutionIds: string[];
  rules: Rule[],
}

export interface Rule {
  name: string;
  type: string;
  url: string;
  condition: string;
}
