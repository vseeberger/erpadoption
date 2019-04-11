<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:ms="urn:schemas-microsoft-com:xslt"
                xmlns:dt="urn:schemas-microsoft-com:datatypes"
                exclude-result-prefixes="msxsl"
                xmlns:cs="urn:cs"
>
  <xsl:output method="html" indent="yes"/>
  <!--<msxsl:script language="C#" implements-prefix="cs">
    <![CDATA[
      public string datenow()
        {
          return(DateTime.Now.ToString("dd'/'MM'/'yyyy"));
        }
      ]]>
  </msxsl:script>-->
  <xsl:template match="ArrayOfAnimalMedicamento">
          <style>
            .tabela td  { border: 2px solid black; text-transform:uppercase; font-family: Tahoma, Arial; font-size:11pt; }
            .tabela2 td { border: 1px solid black; text-transform:uppercase; font-family: Tahoma, Arial; font-size:11pt; }
            .ntop { border-top:0!important; }
            .nleft { border-left:0!important; }
            .nright { border-right:0!important; }
            .nbottom { border-bottom:0!important; }
            h1, h2, h3, h4, h5 { font-size:14pt; }
            .imprimir {
            position: fixed;
            left: 0;
            top: 0;
            }
            @media print {
            .imprimir {
            visibility: hidden;
            }
            @page {
            size: auto;
            margin: 0;
            }
            }
          </style>
          <input type="button" value="IMPRIMIR" onclick="window.print()" class="imprimir" style="padding:5px 10px; border:1px solid; margin:10px 5px;" />
          <br />
          
          <table cellspacing="0" cellpadding="2" width="100%" class="tabela">
            <tr>
              <td rowspan="4" width="150px" style="width:150px;" class="nright">
                <img src="../img/logo.jpg" />
              </td>
              <td align="center" class="nleft nbottom">
                <h1>ABRIGO AME UM PET</h1>
              </td>
            </tr>
            <tr>
              <td class="ntop nleft nbottom"> </td>
            </tr>
            <tr>
              <td class="ntop nleft nbottom" align="center">
                <h2>Agenda de Medicação diária</h2>
              </td>
            </tr>
            <tr>
              <td align="center" class="ntop nleft">
                <h3>
                  
                </h3>
              </td>
            </tr>
          </table>
          
          <table cellspacing="0" cellpadding="1" width="100%" class="tabela2">
            <tr>
              <td class="nright" colspan="2" align="left">Animal</td>
              <td class="nright" align="left">Medicamento</td>
              <td class="nright" align="center">Dose</td>
              <td class="nright" align="center">Vez</td>
              <td width="40px" class=" " align="center">Previsao</td>
            </tr>
            <xsl:for-each select="AnimalMedicamento">
              <xsl:variable name="DataPrevisao" select="DtmPrevisao" />
              <tr>
                <td width="30px" align="center">
                  <input type="checkbox" />
                </td>
                <td>
                  <xsl:value-of select="AnimalMedicado/SNome" />
                </td>
                <td>
                  <xsl:value-of select="Medicamento/SNome" />
                </td>
                <td align="center">
                  <xsl:value-of select="SPosologia" />
                </td>
                <td align="center">
                  <xsl:value-of select="IDose" />º
                </td>
                
                <td align="center">
                  <xsl:value-of select="ms:format-date($DataPrevisao, 'dd/MM')"/>
                </td>
              </tr>
              <!--<p style="page-break-after:always;"></p>-->
            </xsl:for-each>
          </table>
  </xsl:template>
</xsl:stylesheet>