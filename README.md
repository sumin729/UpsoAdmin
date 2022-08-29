# 생활용품점 'Upso' 쇼핑몰 팀 프로젝트 백엔드
- 참여인원:4명
- C#, .net을 이용하여 api 서버 구현 / MS Sql 사용
- 담당 부분
  - 상품 CRUD
   1. 상품 등록(goods/create) post method
   2. 수정(goods/modify) put method
   3. 삭제(goods/delete) delete method
   4. 상품 단일 페이지 조회(goods/detail) get method
   5. 상품 전체 페이지 조회(goods/list) get method
 
   - QnA 답변 등록
   (qna/modify) put method 
  - 페이지네이션 
   1. 총 페이지 갯수(pagesize), 현재 페이지(currentPage)를 통해서 마지막 페이지 넘버(endPaageNo)를 구함.
   2. 변수명
   전체 페이지:totalCount, 요청 페이지 수(currentPage), 시작 페이지(startPageNo)
   3. 사용 예시
   <pre><code>    int skip = (currentPage - 1) * pagesize;
            int take = pagesize;
            int totalCount = GetGoodsTotalCount(goodsid);</code></pre>
  4. 출력 내용 예시
    <pre><code>"data": {
        "pagination": {
            "totalCount": 9,
            "countPerPage": 2,
            "startPageNo": 1,
            "endPageNo": 5,
            "currentPage": 1
        },</code></pre>
