// *
// * @author  모바일 기술팀 KTG
// * @date    2013년 9월 6일 금요일 오전 10:49:21
// *

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CampingReservation.Entity;

namespace CampingReservation.Manager
{
    internal class SiteEntityManager
    {
        private readonly List<SiteEntity> _sites;

        public SiteEntityManager()
        {
            _sites = new List<SiteEntity>
            {
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크101(6×6)", SiteCode = "501"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크102(6×6)", SiteCode = "502"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크103(3×3)", SiteCode = "503"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크104(3×3)", SiteCode = "504"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크105(3×3)", SiteCode = "505"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크106(6×6)", SiteCode = "506"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크107(4×4)", SiteCode = "507"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크108(3×3)", SiteCode = "508"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크109(3×3)", SiteCode = "509"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크110(3×3)", SiteCode = "510"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크201(3×3)", SiteCode = "601"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크202(3×3)", SiteCode = "602"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크203(3×3)", SiteCode = "603"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크204(6×6)", SiteCode = "604"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크205(4×4)", SiteCode = "605"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크206(3×3)", SiteCode = "606"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크207(4×4)", SiteCode = "607"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크208(3×3)", SiteCode = "608"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크209(3×3)", SiteCode = "609"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크210(4×4)", SiteCode = "610"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크211(3×3)", SiteCode = "611"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크212(4×4)", SiteCode = "612"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크213(4×4)", SiteCode = "613"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크214(4×4)", SiteCode = "614"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크215(4×4)", SiteCode = "615"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크216(4×4)", SiteCode = "616"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크217(4×4)", SiteCode = "617"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크301(4×4)", SiteCode = "701"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크302(4×4)", SiteCode = "702"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크303(4×4)", SiteCode = "703"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크304(4×4)", SiteCode = "704"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크305(4×4)", SiteCode = "705"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크306(4×4)", SiteCode = "706"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크307(4×4)", SiteCode = "707"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크308(3×3)", SiteCode = "708"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크309(4×4)", SiteCode = "709"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크310(4×4)", SiteCode = "710"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크311(3×3)", SiteCode = "711"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크312(4×4)", SiteCode = "712"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크313(4×4)", SiteCode = "713"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크401(3×3)", SiteCode = "801"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크402(4×4)", SiteCode = "802"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크403(4×4)", SiteCode = "803"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크404(4×4)", SiteCode = "804"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크405(4×4)", SiteCode = "805"},
                new SiteEntity {Type = ReservationType.축령산자연휴양림, SiteName = "야영데크406(4×4)", SiteCode = "806"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "1-1 사이트", SiteCode = "00000001"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "1-2 사이트", SiteCode = "00000002"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "1-3 사이트", SiteCode = "00000003"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "1-4 사이트", SiteCode = "00000004"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "1-5 사이트", SiteCode = "00000005"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "1-6 사이트", SiteCode = "00000006"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "2-1 사이트", SiteCode = "00000007"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "2-2 사이트", SiteCode = "00000008"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "2-3 사이트", SiteCode = "00000009"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "2-4 사이트", SiteCode = "00000010"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "2-5 사이트", SiteCode = "00000011"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "2-6 사이트", SiteCode = "00000012"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "3-1 사이트", SiteCode = "00000013"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "3-2 사이트", SiteCode = "00000014"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "3-3 사이트", SiteCode = "00000015"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "3-4 사이트", SiteCode = "00000016"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "3-5 사이트", SiteCode = "00000017"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "3-6 사이트", SiteCode = "00000018"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "4-1 사이트", SiteCode = "00000019"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "4-2 사이트", SiteCode = "00000020"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "4-3 사이트", SiteCode = "00000021"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "4-4 사이트", SiteCode = "00000022"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "4-5 사이트", SiteCode = "00000023"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "4-6 사이트", SiteCode = "00000024"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "5-1 사이트", SiteCode = "00000025"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "5-2 사이트", SiteCode = "00000026"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "5-3 사이트", SiteCode = "00000027"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "5-4 사이트", SiteCode = "00000028"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "5-5 사이트", SiteCode = "00000029"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "6-1 사이트", SiteCode = "00000030"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "6-2 사이트", SiteCode = "00000031"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "6-3 사이트", SiteCode = "00000032"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "명당|7-1 사이트", SiteCode = "00000033"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "명당|7-2 사이트", SiteCode = "00000034"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "명당|7-3 사이트", SiteCode = "00000035"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "명당|7-4 사이트", SiteCode = "00000036"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "명당|7-5 사이트", SiteCode = "00000037"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "명당|7-6 사이트", SiteCode = "00000038"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "8-1 사이트", SiteCode = "00000039"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "8-2 사이트", SiteCode = "00000040"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "8-3 사이트", SiteCode = "00000041"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "8-4 사이트", SiteCode = "00000042"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "8-5 사이트", SiteCode = "00000043"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "9-1 사이트", SiteCode = "00000044"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "9-2 사이트", SiteCode = "00000045"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "9-3 사이트", SiteCode = "00000046"},
                new SiteEntity {Type = ReservationType.중랑가족캠핑숲, SiteName = "9-4 사이트", SiteCode = "00000047"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "1 사이트", SiteCode = "00000049"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "2 사이트", SiteCode = "00000050"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "3 사이트", SiteCode = "00000051"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "4 사이트", SiteCode = "00000052"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "5 사이트", SiteCode = "00000053"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "6 사이트", SiteCode = "00000054"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "7 사이트", SiteCode = "00000055"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "8 사이트", SiteCode = "00000056"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "9 사이트", SiteCode = "00000057"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "10 사이트", SiteCode = "00000058"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "11 사이트", SiteCode = "00000059"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "12 사이트", SiteCode = "00000060"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "13 사이트", SiteCode = "00000061"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "14 사이트", SiteCode = "00000062"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "15 사이트", SiteCode = "00000063"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "16 사이트", SiteCode = "00000064"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "17 사이트", SiteCode = "00000065"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "18 사이트", SiteCode = "00000066"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "19 사이트", SiteCode = "00000067"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "20 사이트", SiteCode = "00000068"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "21 사이트", SiteCode = "00000069"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "명당|22 사이트", SiteCode = "00000071"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "명당|23 사이트", SiteCode = "00000072"},
                new SiteEntity {Type = ReservationType.용인자연휴양림, SiteName = "명당|24 사이트", SiteCode = "00000073"}
            };

            #region 축령산

            #endregion

            #region 중랑캠핑숲

            #endregion

            #region 용인자연휴양림

            for (int i = 1; i < 7; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.용인자연휴양림,
                    SiteName = "체험골(5명-8평-6만)" + (i),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 47; i < 49; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.용인자연휴양림,
                    SiteName = "체험골(5명-8평-6만)" + (i - 46),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 7; i < 12; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.용인자연휴양림,
                    SiteName = "느티골(8명-12평-8만)" + (i - 6),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 12; i < 16; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.용인자연휴양림,
                    SiteName = "가마골(10명-15평-10만)" + (i - 11),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 16; i < 21; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.용인자연휴양림,
                    SiteName = "밤티골(13명-20평-13만)" + (i - 15),
                    SiteCode = i.ToString("00000000")
                });
            }

            #endregion

            #region 강동 그린웨이

            _sites.Add(new SiteEntity {Type = ReservationType.강동그린웨이, SiteName = "1 사이트", SiteCode = "00000064"});
            _sites.Add(new SiteEntity {Type = ReservationType.강동그린웨이, SiteName = "2 사이트", SiteCode = "00000065"});
            _sites.Add(new SiteEntity {Type = ReservationType.강동그린웨이, SiteName = "3 사이트", SiteCode = "00000066"});
            _sites.Add(new SiteEntity {Type = ReservationType.강동그린웨이, SiteName = "4 사이트", SiteCode = "00000067"});
            _sites.Add(new SiteEntity {Type = ReservationType.강동그린웨이, SiteName = "5 사이트", SiteCode = "00000068"});
            _sites.Add(new SiteEntity {Type = ReservationType.강동그린웨이, SiteName = "6 사이트", SiteCode = "00000069"});
            _sites.Add(new SiteEntity {Type = ReservationType.강동그린웨이, SiteName = "7 사이트", SiteCode = "00000070"});
            _sites.Add(new SiteEntity {Type = ReservationType.강동그린웨이, SiteName = "8 사이트", SiteCode = "00000071"});

            #endregion

            #region 노을

            _sites.Add(new SiteEntity
            {
                Type = ReservationType.노을캠핑장,
                SiteName = "아이더존E1",
                SiteCode = 4.ToString("00000000")
            });

            for (int i = 66; i < 75; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.노을캠핑장,
                    SiteName = "아이더존E" + (i - 64) + " 사이트",
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 6; i < 14; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.노을캠핑장,
                    SiteName = "A-" + (i - 5) + " 사이트",
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 22; i < 30; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.노을캠핑장,
                    SiteName = "B-" + (i - 21) + " 사이트",
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 38; i < 44; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.노을캠핑장,
                    SiteName = "C-" + (i - 37) + " 사이트",
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 50; i < 58; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.노을캠핑장,
                    SiteName = "D-" + (i - 49) + " 사이트",
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 106; i < 154; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.노을캠핑장,
                    SiteName = "F-" + (i - 105) + " 사이트",
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 154; i < 176; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.노을캠핑장,
                    SiteName = "G-" + (i - 153) + " 사이트",
                    SiteCode = i.ToString("00000000")
                });
            }

            #endregion

            #region 자라섬

            for (int i = 2001; i < 2060; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.자라섬,
                    SiteName = "캐라반사이트A" + (i - 2001+1),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 3024; i < 3051; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.자라섬,
                    SiteName = "명당|캐라반사이트B" + (i - 3024 +1),
                    SiteCode = i.ToString("00000000")
                });
            }


            #region 캐라반
            _sites.Add(new SiteEntity{ Type = ReservationType.자라섬, SiteName = "캐라반B3", SiteCode = "00001003"});
            
            for (int i = 1005; i < 1014; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.자라섬,
                    SiteName = "캐라반B" + (i - 1000),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 3001; i < 3005; i++)
            {
                if (i == 3003) continue;
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.자라섬,
                    SiteName = "캐라반B" + (i - 3000),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 3014; i < 3021; i++)
            {
                if (i == 3003) continue;
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.자라섬,
                    SiteName = "캐라반B" + (i - 3000),
                    SiteCode = i.ToString("00000000")
                });
            }

            #endregion

            for (int i = 4196; i < 4219; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.자라섬,
                    SiteName = "캐라반C" + (i - 4196 +1),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 4001; i < 4192; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.자라섬,
                    SiteName = "오토캠핑" + (i - 4001 + 1),
                    SiteCode = i.ToString("00000000")
                });
            }

            #endregion

            #region 한탄강

            for (int i = 13; i < 21; i++)
            {
                //00000144|00000183
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.한탄강,
                    SiteName = "캐라반 4인용" + (i),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 144; i < 184; i++)
            {
                //00000144|00000183
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.한탄강,
                    SiteName = "언덕사이트 D" + (i - 143),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 43; i < 129; i++)
            {
                if (i - 42 >= 66 && i - 42 <= 74)
                {
                    _sites.Add(new SiteEntity
                    {
                        Type = ReservationType.한탄강,
                        SiteName = "최고명당|자동차 C" + (i - 42),
                        SiteCode = i.ToString("00000000")
                    });
                }
                else if (i - 42 >= 63 && i - 42 <= 86)
                {
                    _sites.Add(new SiteEntity
                    {
                        Type = ReservationType.한탄강,
                        SiteName = "명당|자동차 C" + (i - 42),
                        SiteCode = i.ToString("00000000")
                    });
                }
                else
                {
                    _sites.Add(new SiteEntity
                    {
                        Type = ReservationType.한탄강,
                        SiteName = "자동차 C" + (i - 42),
                        SiteCode = i.ToString("00000000")
                    });
                }
            }

            #endregion

            #region 야인시대

            for (int i = 1; i < 15; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.야인시대,
                    SiteName = "A" + i.ToString("00"),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 51; i < 61; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.야인시대,
                    SiteName = "B" + i.ToString("00"),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 61; i < 71; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.야인시대,
                    SiteName = "C" + i.ToString("00"),
                    SiteCode = i.ToString("00000000")
                });
            }

            for (int i = 71; i < 87; i++)
            {
                _sites.Add(new SiteEntity
                {
                    Type = ReservationType.야인시대,
                    SiteName = "D" + i.ToString("00"),
                    SiteCode = i.ToString("00000000")
                });
            }

            #endregion

            #region 연인산

            for (int i = 1; i < 37; i++)
            {
                _sites.Add(new SiteEntity { Type = ReservationType.연인산, SiteName = "O" + i, SiteCode = i.ToString("00000000") });    
            }
            
            #endregion
            //@"00000001|00000002|00000003|00000004|00000005|00000006|00000007|00000008|00000009|00000010|00000011|00000012|00000013|00000014|00000015|00000016|00000017|00000018|00000019|00000020|00000021|00000047|00000048|00000049|00000050|00000051|00000052|00000053|00000054|00000055|00000056|00000057|00000058|00000059|00000060|00000061|00000062|00000063|00000064|00000065|00000066|00000067|00000068|00000069|00000070|00000071|00000072|00000073|"
        }

        public List<SiteEntity> Sites(ReservationType type)
        {
            return _sites.Where(t => t.Type == type).ToList();
        }
    }
}