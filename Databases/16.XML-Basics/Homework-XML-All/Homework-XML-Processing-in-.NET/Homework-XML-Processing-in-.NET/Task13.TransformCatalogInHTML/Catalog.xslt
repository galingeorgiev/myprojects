<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" version="1.0" encoding="utf-8" indent="yes"/>

    <xsl:template match="/">
      <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
</xsl:text>
      <html>
        <body>
          <h2>Albums</h2>
          <table border="1">
            <tr bgcolor="#CCCCCC">
              <th align="left">Name</th>
              <th align="left">Artist</th>
              <th align="left">Year</th>
              <th align="left">Producer</th>
              <th align="left">Price</th>
              <th align="left">Songs</th>
            </tr>
            <xsl:for-each select="catalog/album">
              <tr>
                <td>
                  <xsl:value-of select="name"/>
                </td>
                <td>
                  <xsl:value-of select="artist"/>
                </td>
                <td>
                  <xsl:value-of select="year"/>
                </td>
                <td>
                  <xsl:value-of select="producer"/>
                </td>
                <td>
                  <xsl:value-of select="price"/>
                </td>
                <td>
                  <ul>
                <xsl:for-each select="songs">
                <li>
                  <xsl:value-of select="title"/> - 
                    <xsl:value-of select="duration"/>
                  </li>
                </xsl:for-each>
                  </ul>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
