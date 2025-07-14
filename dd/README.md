# React 테트리스 게임

## 소개
이 프로젝트는 React 함수형 컴포넌트와 CRA(react-scripts) 구조로 구현된 테트리스 게임입니다.  
useState, useEffect 훅을 활용해 블록 상태와 게임 흐름을 관리하며, CSS 모듈/파일로 스타일링되어 있습니다.

## 폴더 구조
```
src/
  App.js
  App.module.css
  index.js
  index.css
  components/
    Board.js
    Board.module.css
    Cell.js
    Cell.module.css
  utils/
    tetris.js
```

## 주요 기능
- React 함수형 컴포넌트 기반
- useState, useEffect로 상태 및 흐름 관리
- 키보드(←, →, ↓, ↑, Space)로 블록 이동/회전/하드드롭
- 점수, 다음 블록, 게임오버, 재시작 기능
- CSS 모듈/파일로 스타일 분리

## 실행 방법
1. 의존성 설치  
   ```
   npm install
   ```
2. 개발 서버 실행  
   ```
   npm start
   ```
3. 브라우저에서 [http://localhost:3000](http://localhost:3000) 접속

## 조작법
- ←, → : 블록 좌우 이동
- ↓ : 블록 빠르게 내리기
- ↑ : 블록 회전
- Space : 하드드롭(즉시 바닥까지)
- 게임오버 시 "다시 시작" 버튼 클릭

---

## Q&A 누적 기록

Q: 테트리스게임하나만들어온나

A: React 함수형 컴포넌트, useState/useEffect, CRA(react-scripts) 구조, CSS 모듈/파일 분리, Board/Cell/utils 등 폴더별로 구현.  
package.json, src/ 주요 파일, 스타일 파일 모두 생성 및 테트리스 게임 로직/화면/조작 구현 완료.  
README.md에 구조, 실행법, 조작법, Q&A 누적 기록 포함.
Q: 기본적인 index 경로를 public이아닌 폴더에 들어오자마자 하게해줄수있어?

A: CRA(react-scripts) 구조에서 Vite 기반 구조로 마이그레이션하여, index.html을 프로젝트 루트에 두고 Vite 개발 서버(npm run dev)로 실행되도록 전체 구조를 변경함.  
package.json, vite.config.js, index.html, main.jsx 등 Vite 표준 구조로 변경 및 모든 소스/스타일/실행법을 반영.  
실행 명령어는 `npm run dev`, 접속 주소는 [http://localhost:5173](http://localhost:5173)로 변경됨.  
src/index.js → src/main.jsx로 변경, CRA 관련 파일(public/index.html 등) 제거.
