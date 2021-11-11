export interface Group {
  groupId: string;
  institutionIds: string[];
  pushRules: Rule[],
  pullRules: Rule[]
}

export interface Rule {
  name: string;
  url: string;
  condition: string;
}
