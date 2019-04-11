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
  
  <xsl:template match="PedidoCompra">
        <style>
          .tabela td  { border: 2px solid black; text-transform:uppercase; font-family: Tahoma, Arial; font-size:11pt; }
          .tabela2 td { border: 1px solid black; text-transform:uppercase; font-family: Tahoma, Arial; font-size:11pt; }
          .ntop { border-top:0!important; }
          .nleft { border-left:0!important; }
          .nright { border-right:0!important; }
          .nbottom { border-bottom:0!important; }
          h1, h2, h3, h4, h5 { font-size:14pt; }
          h4 {font-size:10pt;}
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
            <td align="center" class="ntop nleft">
              <h4>
                <xsl:value-of select="SDescricao" />
                <p>
                  Código da lista: <xsl:value-of select="Id" />
                </p>
              </h4>
            </td>
          </tr>
        </table>
       
        <table cellspacing="0" cellpadding="1" width="100%" class="tabela2">
          <tr>
            <td class="nright" align="left">Produto</td>
            <td width="40px" class="nright " align="center">Qtd.</td>
            <td width="40px" class="nright " align="center">Comprou</td>
            <td width="40px" class="nright " align="center">Qtd comprado</td>
            <td width="40px" class="nright " align="center">Medicamento</td>
            <td width="40px" class=" " align="center">Vacina</td>
          </tr>
          <xsl:for-each select="LstProdutos/PedidoCompraItens">
            <tr>
              <td class="ntop nright">
                <xsl:value-of select="Produto/SReferencia" /> - <xsl:value-of select="Produto/SNome" />
                <p style="font-size:7pt;">
                  <xsl:value-of select="Produto/SNomeComercial" />
                </p>
              </td>
              
              <td align="center" class="ntop nright">
                <xsl:value-of select="IQuantidade" />
              </td>
              
              <td align="center" class="ntop nright">
                <input type="checkbox" />
              </td>

              <td align="center" class="ntop nright">
                _______
              </td>

              <xsl:variable name="Medicamento" select="Produto/EhMedicamento" />
              <xsl:variable name="Vacina" select="Produto/EhVacina" />
              <td align="center" class="ntop nright">
                <xsl:choose>
                  <xsl:when test="$Medicamento = 'true'">
                    <input type="checkbox" checked="checked" />
                  </xsl:when>
                  <xsl:otherwise>
                    <input type="checkbox" />
                  </xsl:otherwise>
                </xsl:choose>
              </td>

              <td align="center" class="ntop ">
                <xsl:choose>
                  <xsl:when test="$Vacina = 'true'">
                    <input type="checkbox" checked="checked" />
                  </xsl:when>
                  <xsl:otherwise>
                    <input type="checkbox" />
                  </xsl:otherwise>
                </xsl:choose>
              </td>
            </tr>
          </xsl:for-each>
        </table>
  </xsl:template>
</xsl:stylesheet>